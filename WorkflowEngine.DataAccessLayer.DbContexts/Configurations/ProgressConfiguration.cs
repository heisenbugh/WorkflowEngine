using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccessLayer.DbContexts.Configurations
{
    public class ProgressConfiguration : BaseEntityConfiguration<Progress>
    {
        public override void Configure(EntityTypeBuilder<Progress> builder)
        {
            base.Configure(builder); // Must call this

            builder.HasOne(x => x.Request)
                .WithMany(x => x.Progress)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Path)
                .WithMany(x => x.Progress)
                .HasForeignKey(x => x.PathId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.ProgressedBy)
               .WithMany(x => x.Progress)
               .HasForeignKey(x => x.ProgressedById)
               .OnDelete(DeleteBehavior.SetNull);

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
