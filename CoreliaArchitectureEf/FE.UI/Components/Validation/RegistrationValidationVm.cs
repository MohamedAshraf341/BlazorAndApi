using FE.UI.Models.Api.User;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace FE.UI.Components.Validation
{
    public class RegistrationValidationVm:AbstractValidator<RegistrationVm>
    {
        public RegistrationValidationVm()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password can not be empty.")
                .MinimumLength(6).WithMessage("Your password length must be at least 6.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password length must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password length must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password length must contain at least one number.")
                .Matches(@"[\@\!\?\*\.]+").WithMessage("Your password length must contain at least one (@ ! ? * .).");
            RuleFor(x => x.ConfirmPassword).Equal(_ => _.Password).WithMessage("Confirm password equal password.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<RegistrationVm>.CreateWithOptions((RegistrationVm)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
