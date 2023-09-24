using Common.ViewModel.Auth;
using FE.UI.Components.Validation;
using FE.UI.Models.Api.User;
using MudBlazor;
using System.Threading.Tasks;

namespace FE.UI.Pages.Authentication
{
    public partial class Register
    {
        RegistrationVm Item = new RegistrationVm();
        RegistrationValidationVm validationItem = new RegistrationValidationVm();
        MudForm form;
        private async Task RegisterAsync()
        {
            await form.Validate();
            if(form.IsValid)
            {
                var userRegister = new RegisterViewModel
                {
                    Name=Item.Name,
                    Username = Item.Username,
                    Email = Item.Email,
                    Password=Item.Password
                };
                //call api registeration
            }
        }
    }

}