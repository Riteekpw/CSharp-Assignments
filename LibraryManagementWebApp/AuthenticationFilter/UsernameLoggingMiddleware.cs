using System.Security.Claims;
using Serilog.Context;
using System.Threading.Tasks;



namespace LibraryManagementWebApp.AuthenticationFilter
{
    public class UsernameLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public UsernameLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userName = context.User.Identity?.IsAuthenticated == true
                ? context.User.FindFirst(ClaimTypes.Name)?.Value ?? "UnknownUser"
                : "Anonymous";

            using (LogContext.PushProperty("Username", userName)) // Add username dynamically
            {
                await _next(context);
            }
        }
    }
}
