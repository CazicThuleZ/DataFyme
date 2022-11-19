using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class LibraryConfiguration : IEntityTypeConfiguration<VideoFile>
    {
        public void Configure(EntityTypeBuilder<VideoFile> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.DiskVolumeId).IsRequired();
            builder.Property(p => p.FilePath).IsRequired();
            builder.Property(p => p.FileName).IsRequired();
            builder.Property(p => p.EpisodeTitle).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.Size).IsRequired();
            builder.Property(p => p.ThumbnailUrl).IsRequired();
            builder.Property(p => p.ShowTitle).IsRequired();
            builder.Property(p => p.SeasonNumber).IsRequired();
            builder.Property(p => p.EpisodeNumber).IsRequired();            

            builder.HasOne(b => b.DiskVolume).WithMany().HasForeignKey(d => d.DiskVolumeId);
        }
    }
}