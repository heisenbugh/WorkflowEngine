using Haskap.LayeredArchitecture.Core.Specifications;
using System;
using System.Linq.Expressions;
using WorkflowEngine.Core.Entities;

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
