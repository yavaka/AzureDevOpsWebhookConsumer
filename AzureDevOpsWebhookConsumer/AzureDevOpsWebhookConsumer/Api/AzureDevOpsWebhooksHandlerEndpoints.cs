using AzureDevOpsWebhookConsumer.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace AzureDevOpsWebhookConsumer.Api
{
    public static class AzureDevOpsWebhooksHandlerEndpoints
    {
        public static WebApplication MapAzureDevOpsWebhookRepo(this WebApplication app)
        {
            app.MapPost("/webhook/repo", async (HttpContext context) =>
            {
                using var reader = new StreamReader(context.Request.Body);
                try
                {
                    var body = await reader.ReadToEndAsync();

                    var eventTypeModel = JsonConvert.DeserializeObject<EventTypeModel>(body)!;

                    switch (eventTypeModel.EventType)
                    {
                        case "git.push":
                            var gitPushModel = JsonConvert.DeserializeObject<NotificationModel>(body);
                            break;
                        case "git.repo.created":
                            var gitRepoCreatedModel = JsonConvert.DeserializeObject<NotificationModel>(body);
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    await Console.Out.WriteLineAsync(e.Message);
                }
                return Results.Ok();
            });

            return app;
        }
    }
}
