using Haskap.LayeredArchitecture.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Repositories;
using WorkflowEngine.DataAccess.DbContexts;

namespace WorkflowEngine.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : BaseRepository<TEntity, Guid, EfCoreOracleWorkflowEngineDbContext>, IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public BaseRepository(EfCoreOracleWorkflowEngineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
