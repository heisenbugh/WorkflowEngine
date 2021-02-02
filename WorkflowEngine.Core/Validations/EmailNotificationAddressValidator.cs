using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Validations
{
    public class EmailNotificationAddressValidator : AbstractValidator<string>
    {
        public EmailNotificationAddressValidator()
        {
            RuleFor(x => x)
                .EmailAddress();
        }
    }
}
