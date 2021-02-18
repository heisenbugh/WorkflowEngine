using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class EmailNotificationTemplate : BaseEntity
    {
        private List<EmailNotificationAddress> validatedToAddresses;
        private List<EmailNotificationAddress> validatedCcAddresses;
        private List<EmailNotificationAddress> validatedBccAddresses;


        public string Subject { get; set; }
        public IReadOnlyCollection<EmailNotificationAddress> ToAddresses { get; set; }
        public IReadOnlyCollection<EmailNotificationAddress> CcAddresses { get; set; }
        public IReadOnlyCollection<EmailNotificationAddress> BccAddresses { get; set; }
        public Guid ContentId { get; set; }
        public NotificationContentTemplate Content { get; set; }
        public bool IsActive { get; set; }


        public EmailNotificationTemplate()
        {
            validatedToAddresses = new List<EmailNotificationAddress>();
            ToAddresses = validatedToAddresses.AsReadOnly();

            validatedCcAddresses = new List<EmailNotificationAddress>();
            CcAddresses = validatedCcAddresses.AsReadOnly();

            validatedBccAddresses = new List<EmailNotificationAddress>();
            BccAddresses = validatedBccAddresses.AsReadOnly();
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
    }
}
