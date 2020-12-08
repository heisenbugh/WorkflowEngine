using Haskap.LayeredArchitecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.Core.Specifications
{
    public abstract class Specification<TEntity> : Specification<TEntity, Guid>
        where TEntity : BaseEntity
    {
    }
}
