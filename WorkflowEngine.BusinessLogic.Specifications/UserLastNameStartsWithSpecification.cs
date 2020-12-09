using Haskap.LayeredArchitecture.Core.Specifications;
using System;
using System.Linq.Expressions;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.BusinessLogic.Specifications
{
    public class UserLastNameStartsWithSpecification : Specification<User>
    {
        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.LastName.StartsWith("k");
        }
    }
}
