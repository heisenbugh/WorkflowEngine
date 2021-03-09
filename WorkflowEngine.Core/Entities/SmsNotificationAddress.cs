using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkflowEngine.Core.Validations;

namespace WorkflowEngine.Core.Entities
{
    public class SmsNotificationAddress : INotificationAddress
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

        public SmsNotificationAddress(string address)
        {
            this.address = address;
        }

        public bool IsValid()
        {
            var validator = new SmsNotificationAddressValidator();
            var validationResult = validator.Validate(address);
            return validationResult.IsValid;
        }

        public static implicit operator string(SmsNotificationAddress smsNotificationAddress)
        {
            return smsNotificationAddress.address;
        }

        public static implicit operator SmsNotificationAddress(string address)
        {
            return new SmsNotificationAddress(address);
        }

        public string ToFormattedString()
        {
            return Regex.Replace(address, @"(\d{3})(\d{3})(\d{2})(\d{2})", "($1)-$2-$3-$4");
        }

        public override string ToString()
        {
            return address;
        }
    }
}
