using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Loggers;

namespace UnluCo.FinalProject.WebApi.Common.Middlewares
{

    public class AuthenticationAndNavigationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public AuthenticationAndNavigationMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {

            var watch = Stopwatch.StartNew();
            try
            {

                string message = $"[Request HTTP] {context.Request.Method } -- {context.Request.Path}";
                _loggerService.Write(message);

                var token = "";
                if (context.Request.Headers["Authorization"].ToString().Length > 20)
                {

                    token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                    var mySecret = Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM");
                    var mySecurityKey = new SymmetricSecurityKey(mySecret);
                    var tokenHandler = new JwtSecurityTokenHandler();

                    tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "http://localhost:5000/",
                        ValidAudience = "http://localhost:5000/",
                        IssuerSigningKey = mySecurityKey,
                    }, out SecurityToken validatedToken);
                }






                await _next(context);
                watch.Stop();
                message = $"[Response HTTP] {context.Request.Method} -- {context.Request.Path} responded {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds}ms";


                _loggerService.Write(message);
            }
            catch (Exception ex)
            {

                watch.Stop();
                _loggerService.Write(ex.Message);
            }


        }

    }
    public static class AuthenticationAndNavigationMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthenticationAndNavigationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
