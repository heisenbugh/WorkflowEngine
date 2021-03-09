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
        public IEnumerable<EmailNotificationAddress> ToAddresses 
        {
            get
            {
                return validatedToAddresses.AsReadOnly();
            }
            private set
            {
                validatedToAddresses = value.ToList();
            }
        }
        public IEnumerable<EmailNotificationAddress> CcAddresses
        {
            get
            {
                return validatedCcAddresses.AsReadOnly();
            }
            private set
            {
                validatedCcAddresses = value.ToList();
            }
        }
        public IEnumerable<EmailNotificationAddress> BccAddresses
        {
            get
            {
                return validatedBccAddresses.AsReadOnly();
            }
            private set
            {
                validatedBccAddresses = value.ToList();
            }
        }
        public Guid ContentId { get; set; }
        public NotificationContentTemplate Content { get; set; }
        public bool IsActive { get; set; }


        public EmailNotificationTemplate()
        {
            validatedToAddresses = new List<EmailNotificationAddress>();
            //ToAddresses = validatedToAddresses.AsReadOnly();

            validatedCcAddresses = new List<EmailNotificationAddress>();
            //CcAddresses = validatedCcAddresses.AsReadOnly();

            validatedBccAddresses = new List<EmailNotificationAddress>();
            //BccAddresses = validatedBccAddresses.AsReadOnly();
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

        public void UpdateToAddress(int index, EmailNotificationAddress address)
        {
            if (address.IsValid())
            {
                validatedToAddresses[index] = address;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveToAddress(int index)
        {
            validatedToAddresses.RemoveAt(index);
        }

        public void RemoveToAddress(EmailNotificationAddress address)
        {
            validatedToAddresses.Remove(validatedToAddresses.Find(x => x.Address == address.Address));
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

        public void UpdateCcAddress(int index, EmailNotificationAddress address)
        {
            if (address.IsValid())
            {
                validatedCcAddresses[index] = address;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveCcAddress(int index)
        {
            validatedCcAddresses.RemoveAt(index);
        }

        public void RemoveCcAddress(EmailNotificationAddress address)
        {
            validatedCcAddresses.Remove(validatedCcAddresses.Find(x => x.Address == address.Address));
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

        public void UpdateBccAddress(int index, EmailNotificationAddress address)
        {
            if (address.IsValid())
            {
                validatedBccAddresses[index] = address;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveBccAddress(int index)
        {
            validatedBccAddresses.RemoveAt(index);
        }

        public void RemoveBccAddress(EmailNotificationAddress address)
        {
            validatedBccAddresses.Remove(validatedBccAddresses.Find(x => x.Address == address.Address));
        }
    }
}
