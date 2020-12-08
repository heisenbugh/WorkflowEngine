using System;
using System.Linq.Expressions;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Specifications;

namespace WorkflowEngine.BusinessLogic.Specifications
{
    public class FirstLetterUserSpecification : Specification<User>
    {
        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.FirstName.StartsWith("h");
        }
    }
}
