using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FluentValidation;
using System.Linq;
using Common.ViewModel.Auth;

namespace FE.UI.Components.Validation
{
    public class LoginValidationVm : AbstractValidator<LoginViewModel>
    {
        public LoginValidationVm()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Your email can not be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password can not be empty.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<LoginViewModel>.CreateWithOptions((LoginViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
