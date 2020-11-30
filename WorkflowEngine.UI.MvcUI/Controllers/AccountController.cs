using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkflowEngine.Core.Dtos;
using WorkflowEngine.Core.Services;

namespace WorkflowEngine.UI.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddUserInputDto addUserInputDto)
        {
            this.accountService.AddUser(addUserInputDto);

            return View();
        }
    }
}
