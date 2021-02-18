using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Entities
{
    public class NotificationContentTemplate : BaseEntity
    {
        public SmsNotificationTemplate SmsNotificationTemplate { get; set; }
        public EmailNotificationTemplate EmailNotificationTemplate { get; set; }
        public string Content { get; set; }
    }
}
