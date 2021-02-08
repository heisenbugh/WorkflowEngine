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

            var emailNotificationAddressValueComparer = new ValueComparer<IReadOnlyCollection<EmailNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder
                .Property(x => x.ToAddresses)
                .HasField("validatedToAddresses")
                .HasColumnName("TO_ADDRESSES")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.BccAddresses)
                .HasField("validatedBccAddresses")
                .HasColumnName("BCC_ADDRESSES")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.CcAddresses)
                .HasField("validatedCcAddresses")
                .HasColumnName("CC_ADDRESSES")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            var smsNotificationAddressValueComparer = new ValueComparer<IReadOnlyCollection<SmsNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder
                .Property(x => x.GsmNumbers)
                .HasField("validatedGsmNumbers")
                .HasColumnName("GSM_NUMBERS")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new SmsNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(smsNotificationAddressValueComparer);
        }
    }
}
