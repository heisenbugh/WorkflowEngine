using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class Notification : BaseEntity
    {
        private List<EmailNotificationAddress> validatedToAddresses;
        private List<EmailNotificationAddress> validatedCcAddresses;
        private List<EmailNotificationAddress> validatedBccAddresses;
        private List<SmsNotificationAddress> validatedGsmNumbers;

        public string Subject { get; set; }
        public string Content { get; set; }
        public string SmsHeader { get; set; }
        public IReadOnlyCollection<EmailNotificationAddress> ToAddresses { get; set; }
        public IReadOnlyCollection<EmailNotificationAddress> CcAddresses { get; set; }
        public IReadOnlyCollection<EmailNotificationAddress> BccAddresses { get; set; }
        public IReadOnlyCollection<SmsNotificationAddress> GsmNumbers { get; set; }
        public bool IsActive { get; set; }

        public Notification()
        {
            validatedToAddresses = new List<EmailNotificationAddress>();
            ToAddresses = validatedToAddresses.AsReadOnly();

            validatedCcAddresses = new List<EmailNotificationAddress>();
            CcAddresses = validatedCcAddresses.AsReadOnly();

            validatedBccAddresses = new List<EmailNotificationAddress>();
            BccAddresses = validatedBccAddresses.AsReadOnly();

            validatedGsmNumbers = new List<SmsNotificationAddress>();
            GsmNumbers = validatedGsmNumbers.AsReadOnly();
        }

        public void AddToAddress(EmailNotificationAddress address)
        {
            if (address.IsValid())
            {
                validatedToAddresses.Add(address);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddCcAddress(EmailNotificationAddress address)
        {
            if (address.IsValid())
            {
                validatedCcAddresses.Add(address);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddBccAddress(EmailNotificationAddress address)
        {
            if (address.IsValid())
            {
                validatedBccAddresses.Add(address);
            }
            else
            {
                throw new ArgumentException();
            }
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
