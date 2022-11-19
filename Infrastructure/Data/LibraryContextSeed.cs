using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities.Media;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class LibraryContextSeed
    {
        public static async Task SeedAsync(LibraryContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.DiskVolumes.Any())
                {
                    var volumesData = File.ReadAllText("../Infrastructure/Data/SeedData/DiskVolume.json");
                    var volumes = JsonSerializer.Deserialize<List<DiskVolume>>(volumesData);

                    foreach (var volume in volumes)
                    {
                        context.DiskVolumes.Add(volume);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.VideoFiles.Any())
                {
                    var videoFileData = File.ReadAllText("../Infrastructure/Data/SeedData/VideoFile.json");
                    var vfiles = JsonSerializer.Deserialize<List<VideoFile>>(videoFileData);

                    foreach (var vfile in vfiles)
                    {
                        context.VideoFiles.Add(vfile);
                    }

                    await context.SaveChangesAsync();
                }                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<LibraryContextSeed>();
                logger.LogError(ex.Message);                
            }
        }
    }
}