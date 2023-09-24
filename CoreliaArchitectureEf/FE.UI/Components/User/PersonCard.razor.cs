using Common.ViewModel.Auth;
using FE.UI.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FE.UI.Components.User
{
    public partial class PersonCard
    {
        [Inject] AuthenticationService AuthenticationService { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public string Style { get; set; }
        public ResponseAuthDto User { get; private set; }
        protected override async Task OnInitializedAsync()
        {
            User = AuthenticationService.GetUser();
            await base.OnInitializedAsync();
        }

    }
}