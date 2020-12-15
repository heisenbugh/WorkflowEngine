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
    public class StartStateSpecification : Specification<State>
    {
        private readonly Guid processId;

        public StartStateSpecification(Guid processId)
        {
            this.processId = processId;
        }

        public override Expression<Func<State, bool>> ToExpression()
        {
            return state => state.ProcessId == this.processId && state.StateType.Name == "StartState";
        }
    }
}
