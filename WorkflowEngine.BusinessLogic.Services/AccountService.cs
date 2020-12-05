using Haskap.LayeredArchitecture.BussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Dtos;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.UnitOfWork;
using WorkflowEngine.Core.Services;

namespace WorkflowEngine.BusinessLogic.Services
{
    public class AccountService : BaseService<IWorkflowEngineUnitOfWork>, IAccountService
    {
        public AccountService(IWorkflowEngineUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void AddUser(AddUserInputDto addUserInputDto)
        {
            var user = new User
            {
                FirstName = addUserInputDto.FirstName,
                LastName = addUserInputDto.LastName
            };
            UnitOfWork.GetRepository<User>().Add(user);
            UnitOfWork.SaveChanges();
        }
    }
}
