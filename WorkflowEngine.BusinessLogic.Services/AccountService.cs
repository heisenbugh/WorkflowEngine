using Haskap.LayeredArchitecture.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Dtos;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.UnitOfWork;
using WorkflowEngine.Core.Services;
using WorkflowEngine.BusinessLogic.Specifications;
using System.Linq;
using Haskap.LayeredArchitecture.Core.Specifications;

namespace WorkflowEngine.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IWorkflowEngineUnitOfWork unitOfWork;
        public AccountService(IWorkflowEngineUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddUser(AddUserInputDto addUserInputDto)
        {
            var user = new User
            {
                FirstName = addUserInputDto.FirstName,
                LastName = addUserInputDto.LastName
            };
            this.unitOfWork.GetRepository<User>().Add(user);
            this.unitOfWork.SaveChanges();
        }

        public IList<HasanUserDto> GetHasanUserList()
        {
            var userFirstNameStartsWithSpecification = new UserFirstNameStartsWithSpecification();
            var userLastNameStartsWithSpecification = new UserLastNameStartsWithSpecification();
            var hasanUserDtos = this.unitOfWork.GetRepository<User>().GetMany(userFirstNameStartsWithSpecification.And(userLastNameStartsWithSpecification), string.Empty).Select(x=> new HasanUserDto { 
                Id = x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName
            });

            return hasanUserDtos.ToList();
        }
    }
}
