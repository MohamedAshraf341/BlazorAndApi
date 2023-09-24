using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Common.ViewModel.Auth;

namespace FE.UI.Services
{
    public class BlazorCookieLoginMiddleware
    {
        public static IDictionary<Guid, ResponseAuthDto> Logins { get; private set; }
            = new ConcurrentDictionary<Guid, ResponseAuthDto>();


        private readonly RequestDelegate _next;

        public BlazorCookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, AuthenticationService authenticationService)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var user = Logins[key];

                //var result = await signInMgr.PasswordSignInAsync(info.Email, info.Password, false, lockoutOnFailure: true);
                var result = authenticationService.SetUser(user);
                //if (result.Succeeded)
                if (result)
                {
                    Logins.Remove(key);

                    var returnUrl = context.Request.Query["returnUrl"];

                    if (string.IsNullOrEmpty(returnUrl))
                        context.Response.Redirect("/");
                    else
                        context.Response.Redirect(returnUrl);
                    return;
                }
                //else if (result.RequiresTwoFactor)
                //{
                //    //TODO: redirect to 2FA razor component
                //    context.Response.Redirect("/loginwith2fa/" + key);
                //    return;
                //}
                else
                {
                    //TODO: Proper error handling
                    context.Response.Redirect("/loginfailed");
                    return;
                }
            }
            else if (context.Request.Path == "/logout")
            {
                authenticationService.Logout();
                var returnUrl = context.Request.Query["returnUrl"];

                if (string.IsNullOrEmpty(returnUrl))
                    context.Response.Redirect("/");
                else
                    context.Response.Redirect(returnUrl);
                return;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }

}
