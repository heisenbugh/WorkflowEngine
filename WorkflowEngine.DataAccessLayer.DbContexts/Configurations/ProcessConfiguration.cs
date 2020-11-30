using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccessLayer.DbContexts.Configurations
{
    public class ProcessConfiguration : BaseEntityConfiguration<Process>
    {
        public override void Configure(EntityTypeBuilder<Process> builder)
        {
            base.Configure(builder); // Must call this

            builder.HasMany(x => x.States)
                .WithOne(x => x.Process)
                .HasForeignKey(x => x.ProcessId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Requests)
                .WithOne(x => x.Process)
                .HasForeignKey(x => x.ProcessId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Actions)
                .WithOne(x => x.Process)
                .HasForeignKey(x => x.ProcessId)
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
