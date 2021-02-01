using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class SmsNotificationAddress : INotificationAddress
    {
        private string address;

        public SmsNotificationAddress(string address)
        {
            this.address = address;
        }

        public bool IsValid()
        {
            return address.Length == 10;
        }

        public static implicit operator string(SmsNotificationAddress smsNotificationAddress)
        {
            return smsNotificationAddress.address;
        }

        public static implicit operator SmsNotificationAddress(string address)
        {
            return new SmsNotificationAddress(address);
        }
    }
}
