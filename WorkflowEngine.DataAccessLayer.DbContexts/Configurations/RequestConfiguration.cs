using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccessLayer.DbContexts.Configurations
{
    public class RequestConfiguration : BaseEntityConfiguration<Request>
    {
        public override void Configure(EntityTypeBuilder<Request> builder)
        {
            base.Configure(builder); // Must call this

            builder.HasOne(x => x.RequestedBy)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.RequestedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.CurrentState)
                .WithMany(u => u.Requests)
                .HasForeignKey(ur => ur.CurrentStateId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Data)
                .WithOne(x => x.Request)
                .HasForeignKey<RequestData>(x => x.RequestId)
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
