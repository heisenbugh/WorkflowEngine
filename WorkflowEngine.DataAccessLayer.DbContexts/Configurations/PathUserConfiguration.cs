using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccessLayer.DbContexts.Configurations
{
    public class PathUserConfiguration : BaseEntityConfiguration<PathUser>
    {
        public override void Configure(EntityTypeBuilder<PathUser> builder)
        {
            base.Configure(builder); // Must call this

            builder.HasOne(x => x.Path)
                .WithMany(x => x.PathUsers)
                .HasForeignKey(x => x.PathId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PathUsers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.Property(x => x.ClusteredIndex).UseIdentityAlwaysColumn();
            //builder.ForNpgsqlHasIndex(x => x.ClusteredIndex).IsUnique();

            //builder.HasMany(x => x.RecordLogs)
            //    .WithOne()
            //    .HasForeignKey(x => x.RecordId)
            //    .OnDelete(DeleteBehavior.Cascade); // bu relation drop edilen kaydın logları silinmemesi için commentlendi. 
        }
    }
}
