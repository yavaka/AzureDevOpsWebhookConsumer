using AzureDevOpsWebhookConsumer.Configuration;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using System.Text;

namespace AzureDevOpsWebhookConsumer.Common.Middlewares
{
    public class BasicAuthenticationMiddleware(
        RequestDelegate next, 
        IOptions<BasicAuthCredentialsOptions> options)
    {
        private readonly RequestDelegate _next = next;
        private readonly BasicAuthCredentialsOptions _options = options.Value;

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Equals("/"))
            {
                await _next(context);
                return;
            }

            var authorizeHeader = context.Request.Headers.Authorization.ToString()!;
            var test = context.Request.BodyReader.ToString();
            if (authorizeHeader is not null && authorizeHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authorizeHeader["Basic ".Length..];
                var usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                var credentials = usernamePassword.Split(':');

                if (credentials.Length == 2 &&
                    credentials[0] == _options.Username &&
                    credentials[1] == _options.Password)
                {
                    await _next(context); // Authorized, continue processing request
                    return;
                }
            }

            // Unauthorized - Challenge the client
            context.Response.StatusCode = 401;
            context.Response.Headers.WWWAuthenticate = "Basic realm=\"Protected API\"";
            await context.Response.WriteAsync("You are not authorized");
        }
    }
}
