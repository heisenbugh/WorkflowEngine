using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccess.DbContexts.Configurations
{
    public class ActionConfiguration : BaseEntityConfiguration<Core.Entities.Action>
    {
        public override void Configure(EntityTypeBuilder<Core.Entities.Action> builder)
        {
            base.Configure(builder); // Must call this

            builder.Property(e => e.ActionType)
                .HasConversion<string>();
        }
    }
}
