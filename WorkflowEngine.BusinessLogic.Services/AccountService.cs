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

        public IList<HasanUserDto> GetHasanUserList()
        {
            var specification = new FirstLetterUserSpecification();
            var hasanUserDtos = UnitOfWork.GetRepository<User>().GetMany(specification.ToExpression(), string.Empty).Select(x=> new HasanUserDto { 
                Id = x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName
            });

            return hasanUserDtos.ToList();
        }
    }
}
