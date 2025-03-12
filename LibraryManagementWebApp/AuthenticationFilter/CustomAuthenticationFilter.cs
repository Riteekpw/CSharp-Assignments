using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace LibraryManagementWebApp.AuthenticationFilter
{
    public class CustomAuthenticationFilter : IAsyncActionFilter
    {
        private const string UsernameHeaderName = "Username";  
        private const string PasswordHeaderName = "Password";  

        private const string ValidUsername = "admin"; 
        private const string ValidPassword = "password123";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           
            if (!context.HttpContext.Request.Headers.TryGetValue(UsernameHeaderName, out StringValues username) ||
                string.IsNullOrWhiteSpace(username) ||
                !context.HttpContext.Request.Headers.TryGetValue(PasswordHeaderName, out StringValues password) ||
                string.IsNullOrWhiteSpace(password))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (username != ValidUsername || password != ValidPassword)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }

}


