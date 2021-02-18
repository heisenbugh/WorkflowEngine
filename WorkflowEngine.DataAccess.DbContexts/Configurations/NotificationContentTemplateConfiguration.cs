using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccess.DbContexts.Configurations
{
    public class NotificationContentTemplateConfiguration : BaseEntityConfiguration<NotificationContentTemplate>
    {
        public override void Configure(EntityTypeBuilder<NotificationContentTemplate> builder)
        {
            base.Configure(builder); // Must call this

            builder.HasOne(x => x.SmsNotificationTemplate)
                .WithOne(x => x.Content)
                .HasForeignKey<SmsNotificationTemplate>(x => x.ContentId);

            builder.HasOne(x => x.EmailNotificationTemplate)
                .WithOne(x => x.Content)
                .HasForeignKey<EmailNotificationTemplate>(x => x.ContentId);
        }
    }
}
