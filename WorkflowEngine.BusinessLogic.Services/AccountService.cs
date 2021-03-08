using Haskap.LayeredArchitecture.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Dtos;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Services;
using WorkflowEngine.BusinessLogic.Specifications;
using System.Linq;
using Haskap.LayeredArchitecture.Core.Specifications;
using WorkflowEngine.DataAccess.DbContexts;

namespace WorkflowEngine.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly EfCoreNpgsqlWorkflowEngineDbContext workflowEngineDbContext;
        public AccountService(EfCoreNpgsqlWorkflowEngineDbContext workflowEngineDbContext)
        {
            this.workflowEngineDbContext = workflowEngineDbContext;
        }

        public void AddUser(AddUserInputDto addUserInputDto)
        {
            var user = new User
            {
                FirstName = addUserInputDto.FirstName,
                LastName = addUserInputDto.LastName
            };
            this.workflowEngineDbContext.User.Add(user);
            this.workflowEngineDbContext.SaveChanges();
        }

        public IList<HasanUserDto> GetHasanUserList()
        {
            var userFirstNameStartsWithSpecification = new UserFirstNameStartsWithSpecification();
            var userLastNameStartsWithSpecification = new UserLastNameStartsWithSpecification();
            var hasanUserDtos = this.workflowEngineDbContext.User
                .Where(userFirstNameStartsWithSpecification.And(userLastNameStartsWithSpecification))
                .Select(x => new HasanUserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });

            return hasanUserDtos.ToList();
        }
    }
}
