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
        IBaseRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity;
    }
}
