using Haskap.LayeredArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.Core.Services
{
    public interface INotificationTemplateService : IBaseService
    {
        void AddSmsNotificationTemplate(SmsNotificationTemplate smsNotificationTemplate);
        IList<SmsNotificationTemplate> GetAllSmsNotificationTemplates();
        void DummyUpdate();
    }
}
