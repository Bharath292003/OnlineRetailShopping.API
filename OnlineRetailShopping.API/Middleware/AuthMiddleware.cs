using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using System.Threading.Tasks;

namespace OnlineRetailShopping.API.Middleware
{
    public class AuthMiddleware:IMiddleware
    {
        private readonly IAuthorizationRepository _authorizationRepository;

        public AuthMiddleware(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

        public async Task InvokeAsync(HttpContext httpContext,RequestDelegate next)
        {
                string ID=httpContext.User.Claims.First(c=>c.Type=="Id")?.Value;
                int userid= int.Parse(ID);
            User user = await _authorizationRepository.Role(userid);
            if (user == null)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.WriteAsync("Unauthorized");
            }
            else await next(httpContext);
        }
    }

    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
