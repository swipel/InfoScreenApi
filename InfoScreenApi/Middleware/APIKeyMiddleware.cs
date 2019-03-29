using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Uniconta.Middleware
{
    public class APIKeyMiddleware
    {
        private const string APIKEY = "KMzkkAgjh52W-yD6Uqtcnu%YFZjU=t-sLQ6+Y*rrGeUSKUd@U-=Gx&$*@UQ3KNn9";

        private RequestDelegate next;

        public APIKeyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool validKey = false;
            var checkApiKeyExists = context.Request.Headers.ContainsKey("APIKey");
            if (checkApiKeyExists)
            {
                if (context.Request.Headers["APIKey"].Equals(APIKEY))
                {
                    validKey = true;
                }

                if (!validKey)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync("Invalid API Key");
                }
                else
                {
                    await next.Invoke(context);
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("No api key found");
            }
        }
    }
    public static class MYHandlerExtensions
    {
        public static IApplicationBuilder UseAPIKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIKeyMiddleware>();
        }
    }
}
