using API.Extensions;
using API.Helpers;
using API.Middleware;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IVideoFileRepository, VideoFileRepository>();
            services.AddScoped<IDiskVolumeRepository, VideoFileRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();
            services.AddDbContext<LibraryContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            services.AddApplicationServices();
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwaggerDocumentation();

            if (env.IsDevelopment())
            {
                //   app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
