using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.Core.Validations
{
    public class EmailNotificationAddressValidator : AbstractValidator<EmailNotificationAddress>
    {
        public EmailNotificationAddressValidator()
        {
            Regex regex = new Regex(@"{{.*}}");
            RuleFor(x => x.Address)
                .EmailAddress().When(x => regex.IsMatch(x) == false);
        }
    }
}
