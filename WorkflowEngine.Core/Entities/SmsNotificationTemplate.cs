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
        public IEnumerable<SmsNotificationAddress> GsmNumbers 
        { 
            get
            {
                return validatedGsmNumbers.AsReadOnly();
            } 
        }
        public Guid ContentId { get; set; }
        public NotificationContentTemplate Content { get; set; }
        public bool IsActive { get; set; }

        public SmsNotificationTemplate()
        {
            validatedGsmNumbers = new List<SmsNotificationAddress>();
            //GsmNumbers = validatedGsmNumbers.AsReadOnly();
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

        public void UpdateGsmNumber(int index, SmsNotificationAddress gsmNumber)
        {
            if (gsmNumber.IsValid())
            {
                validatedGsmNumbers[index] = gsmNumber;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
