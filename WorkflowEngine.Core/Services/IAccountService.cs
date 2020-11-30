using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Dtos;

namespace WorkflowEngine.Core.Services
{
    public interface IAccountService : IBaseService
    {
        void AddUser(AddUserInputDto addUserInputDto);
    }
}
