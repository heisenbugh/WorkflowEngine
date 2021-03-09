using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Validations;

namespace WorkflowEngine.Core.Entities
{
    public class EmailNotificationAddress : INotificationAddress
    {
        private string address;

        public string Address
        {
            get
            {
                return address;
            }
            private set
            {
                address = value;
            }
        }

        public EmailNotificationAddress(string address)
        {
            this.address = address;
        }

        public bool IsValid()
        {
            var validator = new EmailNotificationAddressValidator();
            var validationResult = validator.Validate(address);
            return validationResult.IsValid;
        }

        public static implicit operator string(EmailNotificationAddress emailNotificationAddress)
        {
            return emailNotificationAddress.address;
        }

        public static implicit operator EmailNotificationAddress(string address)
        {
            return new EmailNotificationAddress(address);
        }

        public override string ToString()
        {
            return address;
        }
    }
}
