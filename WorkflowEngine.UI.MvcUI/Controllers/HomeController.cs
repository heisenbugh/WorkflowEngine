using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Services;
using WorkflowEngine.UI.MvcUI.Models;

namespace WorkflowEngine.UI.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotificationTemplateService notificationTemplateService;

        public HomeController(ILogger<HomeController> logger, INotificationTemplateService notificationTemplateService)
        {
            _logger = logger;
            this.notificationTemplateService = notificationTemplateService;
        }

        public IActionResult Index()
        {
            NotificationContentTemplate notificationContentTemplate = new NotificationContentTemplate
            {
                Content = "New Content 2"
            };
            SmsNotificationTemplate smsNotificationTemplate = new SmsNotificationTemplate
            {
                Content = notificationContentTemplate,
                IsActive = true
            };
            smsNotificationTemplate.AddGsmNumber("1234567890");
            smsNotificationTemplate.AddGsmNumber("1234567891");
            //notificationTemplateService.AddSmsNotificationTemplate(smsNotificationTemplate);
            var x = notificationTemplateService.GetAllSmsNotificationTemplates();
            notificationTemplateService.DummyUpdate();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
