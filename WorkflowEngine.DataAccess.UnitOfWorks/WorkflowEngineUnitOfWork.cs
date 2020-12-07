using Haskap.LayeredArchitecture.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Repositories;
using WorkflowEngine.Core.UnitOfWork;
using WorkflowEngine.DataAccess.DbContexts;
using WorkflowEngine.DataAccess.Repositories;

namespace WorkflowEngine.DataAccess.UnitOfWorks
{
    public class WorkflowEngineUnitOfWork : BaseUnitOfWork<EfCoreOracleWorkflowEngineDbContext>, IWorkflowEngineUnitOfWork
    {
        public IBaseRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity
        {
            var repository = this.dbContext.GetService<IBaseRepository<TEntity>>();
            if (repository != null)
            {
                return repository;
            }

            throw new NullReferenceException();
        }

        public WorkflowEngineUnitOfWork(EfCoreOracleWorkflowEngineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
