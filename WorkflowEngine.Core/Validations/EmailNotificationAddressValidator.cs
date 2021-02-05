using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Validations
{
    public class EmailNotificationAddressValidator : AbstractValidator<string>
    {
        public EmailNotificationAddressValidator()
        {
            Regex regex = new Regex(@"{{.*}}");
            RuleFor(x => x)
                .EmailAddress().When(x => regex.IsMatch(x) == false);
        }
    }
}
