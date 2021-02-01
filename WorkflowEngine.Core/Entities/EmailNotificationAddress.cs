using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class EmailNotificationAddress : INotificationAddress
    {
        private string address;

        public EmailNotificationAddress(string address)
        {
            this.address = address;
        }

        public bool IsValid()
        {
            return address.Contains("@");
        }

        public static implicit operator string(EmailNotificationAddress emailNotificationAddress)
        {
            return emailNotificationAddress.address;
        }

        public static implicit operator EmailNotificationAddress(string address)
        {
            return new EmailNotificationAddress(address);
        }
    }
}
