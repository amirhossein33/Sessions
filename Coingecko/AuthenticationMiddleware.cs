using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Coingecko
{
    namespace Coingecko
    {
        public class AuthenticationMiddleware
        {
            private readonly RequestDelegate _next;

            public AuthenticationMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                
                if (context.User?.Identity == null || !context.User.Identity.IsAuthenticated)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized: Invalid or missing token.");
                    return;
                }

              
                await _next(context);
            }
        }

        public static class AuthenticationMiddlewareExtensions
        {
            public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app)
            {
                return app.UseMiddleware<AuthenticationMiddleware>();
            }
        }
    }

}
