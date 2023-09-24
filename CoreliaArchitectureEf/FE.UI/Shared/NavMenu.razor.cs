using FE.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FE.UI.Shared
{
    public partial class NavMenu
    {
        [Inject] AuthenticationService authService { get; set; }

    }
}