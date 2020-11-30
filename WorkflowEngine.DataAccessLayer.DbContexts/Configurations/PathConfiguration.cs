using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace WorkflowEngine.DataAccessLayer.DbContexts.Configurations
{
    public class PathConfiguration : BaseEntityConfiguration<Path>
    {
        public override void Configure(EntityTypeBuilder<Path> builder)
        {
            base.Configure(builder); // Must call this

            builder.HasOne(x => x.Action)
                .WithMany(x => x.Paths)
                .HasForeignKey(x => x.ActionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.FromState)
                .WithMany(x => x.FromPaths)
                .HasForeignKey(x => x.FromStateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ToState)
               .WithMany(x => x.ToPaths)
               .HasForeignKey(x => x.ToStateId)
               .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(ur => ur.User)
            //    .WithMany(u => u.UserRoles)
            //    .HasForeignKey(ur => ur.UserId);

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
