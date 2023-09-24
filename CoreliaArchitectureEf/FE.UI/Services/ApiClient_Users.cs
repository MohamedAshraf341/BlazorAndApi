using Common.ViewModel.Auth;
using System.Threading.Tasks;

namespace FE.UI.Services
{
    public class ApiClient_Users : ApiClientBase
    {
        public ApiClient_Users(ApiHttpClient apiHttpClient) : base(apiHttpClient)
        {
        }
        internal async Task<ResponseAuthDto> Authenticate(string Email, string password)
        {
            var request = new LoginViewModel
            {
                Email = Email,
                Password = password,
            };

            var res = await ApiHttpClient.Post<LoginViewModel, ResponseAuthDto>("auth/login", request);
            return res;
        }
        internal async Task<ResponseAuthDto> Login(LoginViewModel request)
        {
            var res = await ApiHttpClient.Post<LoginViewModel, ResponseAuthDto>("auth/login", request);
            return res;
        }
        internal async Task<ResponseAuthDto> Register(RegisterViewModel request)
        {
            var res = await ApiHttpClient.Post<RegisterViewModel, ResponseAuthDto>("auth/register", request);
            return res;
        }
    }
}
