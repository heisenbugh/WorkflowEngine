using Haskap.LayeredArchitecture.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Repositories;

namespace WorkflowEngine.Core.UnitOfWork
{
    public interface IWorkflowEngineUnitOfWork : IBaseUnitOfWork
    {
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<Entities.Action> ActionRepository { get; }
        IBaseRepository<Path> PathRepository { get; }
        IBaseRepository<PathUser> PathUserRepository { get; }
        IBaseRepository<Process> ProcessRepository { get; }
        IBaseRepository<ProcessAdmin> ProcessAdminRepository { get; }
        IBaseRepository<Progress> ProgressRepository { get; }
        IBaseRepository<Request> RequestRepository { get; }
        IBaseRepository<State> StateRepository { get; }
        IBaseRepository<StateUser> StateUserRepository { get; }
    }
}
