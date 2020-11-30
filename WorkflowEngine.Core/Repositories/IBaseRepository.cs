using Haskap.LayeredArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.Core.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
         where TEntity : BaseEntity
    {
    }
}
