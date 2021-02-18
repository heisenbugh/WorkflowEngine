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
    public class SmsNotificationTemplateConfiguration : BaseEntityConfiguration<SmsNotificationTemplate>
    {
        public override void Configure(EntityTypeBuilder<SmsNotificationTemplate> builder)
        {
            base.Configure(builder); // Must call this

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
