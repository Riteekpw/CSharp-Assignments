using LibraryManagementWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagementWebApp.AuthenticationFilter
{
    public class BasicAuthAttribute : IAsyncAuthorizationFilter
    {
        private readonly LibraryContext _context;
        private readonly ILogger _logger;
        public BasicAuthAttribute(LibraryContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            var headers = context.HttpContext.Request.Headers;
            if (!headers.ContainsKey("Username") || !headers.ContainsKey("Password"))
            {
                _logger.LogInformation("user is not authenticated!!");
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.HttpContext.Response.WriteAsync("Missing credentials.");
                return;
            }

            var username = headers["Username"].ToString();
            var password = headers["Password"].ToString();


            if (ValidateUser(username, password, out string role))
            {
                _logger.LogInformation("User Validated with credentials!!");
                var claims = new[] { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, role) };
                var identity = new ClaimsIdentity(claims, "Basic");
                var principal = new ClaimsPrincipal(identity);
                context.HttpContext.User = principal;
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.HttpContext.Response.WriteAsync("Invalid Credentials.");
            }
        }

        private bool ValidateUser(string username, string password, out string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
  
                if (user.Password == password)  
                {
                    role = user.Role;
                    return true;
                }
            }

            role = null;
            return false;
        }
    }
}
