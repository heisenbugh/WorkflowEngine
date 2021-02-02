using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Validations
{
    public class SmsNotificationAddressValidator : AbstractValidator<string>
    {
        public SmsNotificationAddressValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .Length(10, 10)
                .Matches(@"^\d{10}$"); // only 10 digit
        }
    }
}
