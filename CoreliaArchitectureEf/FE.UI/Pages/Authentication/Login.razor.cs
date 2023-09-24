using Common.ViewModel.Auth;
using FE.UI.Components.Validation;
using FE.UI.Extensions;
using FE.UI.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Serilog;
using System;
using System.Threading.Tasks;

namespace FE.UI.Pages.Authentication
{
    public partial class Login
    {
        private bool loading;
        [Inject] Services.NotficationServices Notfication { get; set; }

        [Inject] ApiClient ApiClient { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        LoginViewModel Item = new LoginViewModel();
        LoginValidationVm validationItem = new LoginValidationVm();
        MudForm form;

        private async Task LoginAsync()
        {
            await form.Validate();
            if (form.IsValid)
            {
                loading = true;
                StateHasChanged();

                try
                {
                    var (res, user) = await ApiClient.CanLogin(Item.Email, Item.Password);

                    if (res)
                    {
                        Guid key = Guid.NewGuid();
                        BlazorCookieLoginMiddleware.Logins[key] = user;
                        var returnUrl = NavigationManager.QueryString("returnUrl") ?? "";
                        NavigationManager.NavigateTo($"/login?key={key}&returnUrl={returnUrl}", true);
                        Notfication.ShowMessageSuccess(user.Message);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Notfication.ShowMessageError(ex.Message);

                    Log.Error($"Login.HandleValidSubmit :: Unhandled Exception : {ex}");
                }

                loading = false;
                StateHasChanged();

                await DialogService.ShowMessageBox("Authentication", "Login incorrect.");
            }
        }
    }
}