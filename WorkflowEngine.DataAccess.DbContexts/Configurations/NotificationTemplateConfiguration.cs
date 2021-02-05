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
    public class NotificationTemplateConfiguration : BaseEntityConfiguration<NotificationTemplate>
    {
        public override void Configure(EntityTypeBuilder<NotificationTemplate> builder)
        {
            base.Configure(builder); // Must call this

            var emailNotificationAddressValueComparer = new ValueComparer<List<EmailNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder
                .Property(x => x.ToAddresses)
                .HasField("validatedToAddresses")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.BccAddresses)
                .HasField("validatedBccAddresses")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.CcAddresses)
                .HasField("validatedCcAddresses")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            var smsNotificationAddressValueComparer = new ValueComparer<List<SmsNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder
                .Property(x => x.GsmNumbers)
                .HasField("validatedGsmNumbers")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new SmsNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(smsNotificationAddressValueComparer);
        }
    }
}
