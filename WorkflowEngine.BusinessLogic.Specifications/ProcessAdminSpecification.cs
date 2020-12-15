using Haskap.LayeredArchitecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.BusinessLogic.Specifications
{
    public class ProcessAdminSpecification : Specification<ProcessAdmin>
    {
        private readonly Guid processId;
        private readonly Guid userId;

        public ProcessAdminSpecification(Guid processId, Guid userId)
        {
            this.processId = processId;
            this.userId = userId;
        }

        public override Expression<Func<ProcessAdmin, bool>> ToExpression()
        {
            return x => x.AdminId == userId && x.ProcessId == processId;
        }
    }
}
