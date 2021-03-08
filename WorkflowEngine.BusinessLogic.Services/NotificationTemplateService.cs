using Haskap.LayeredArchitecture.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Services;
using WorkflowEngine.DataAccess.DbContexts;

namespace WorkflowEngine.BusinessLogic.Services
{
    public class NotificationTemplateService : BaseService, INotificationTemplateService
    {
        private readonly EfCoreNpgsqlWorkflowEngineDbContext workflowEngineDbContext;

        public NotificationTemplateService(EfCoreNpgsqlWorkflowEngineDbContext workflowEngineDbContext)
        {
            this.workflowEngineDbContext = workflowEngineDbContext;
        }

        public void AddSmsNotificationTemplate(SmsNotificationTemplate smsNotificationTemplate)
        {
            workflowEngineDbContext.SmsNotificationTemplate.Add(smsNotificationTemplate);
            workflowEngineDbContext.SaveChanges();
        }

        public void DummyUpdate()
        {
            var x = workflowEngineDbContext.SmsNotificationTemplate.FirstOrDefault();
            x.AddGsmNumber("2222222222");
            x.UpdateGsmNumber(0, "3333333333");
            workflowEngineDbContext.SaveChanges();
        }

        public IList<SmsNotificationTemplate> GetAllSmsNotificationTemplates()
        {
            return workflowEngineDbContext.SmsNotificationTemplate.ToList();
        }
    }
}
