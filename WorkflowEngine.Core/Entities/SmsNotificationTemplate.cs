using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class SmsNotificationTemplate : BaseEntity
    {
        private List<SmsNotificationAddress> validatedGsmNumbers;

        public string Header { get; set; }
        public IReadOnlyCollection<SmsNotificationAddress> GsmNumbers { get; set; }
        public Guid ContentId { get; set; }
        public NotificationContentTemplate Content { get; set; }
        public bool IsActive { get; set; }

        public SmsNotificationTemplate()
        {
            validatedGsmNumbers = new List<SmsNotificationAddress>();
            GsmNumbers = validatedGsmNumbers.AsReadOnly();
        }

        public void AddGsmNumber(SmsNotificationAddress gsmNumber)
        {
            if (gsmNumber.IsValid())
            {
                validatedGsmNumbers.Add(gsmNumber);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
