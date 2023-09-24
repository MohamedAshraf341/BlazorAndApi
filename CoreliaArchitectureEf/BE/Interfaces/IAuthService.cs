using Common.ViewModel;
using Common.ViewModel.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseAuthDto> RegisterAsync(RegisterViewModel model);
        Task<ResponseAuthDto> GetTokenAsync(LoginViewModel model);
        Task<string> AddRoleAsync(AddRoleViewModel model);
        Task<ResponseAuthDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        List<Role> GetRoles();
    }
}
