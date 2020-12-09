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
            var userFirstNameStartsWithSpecification = new UserFirstNameStartsWithSpecification();
            var userLastNameStartsWithSpecification = new UserLastNameStartsWithSpecification();
            var hasanUserDtos = UnitOfWork.GetRepository<User>().GetMany(userFirstNameStartsWithSpecification.And(userLastNameStartsWithSpecification), string.Empty).Select(x=> new HasanUserDto { 
                Id = x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName
            });

            return hasanUserDtos.ToList();
        }
    }
}
