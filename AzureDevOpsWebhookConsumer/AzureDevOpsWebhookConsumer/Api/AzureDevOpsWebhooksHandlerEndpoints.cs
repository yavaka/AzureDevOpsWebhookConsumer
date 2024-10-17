using AzureDevOpsWebhookConsumer.Api.Dtos;
using AzureDevOpsWebhookConsumer.Data;
using AzureDevOpsWebhookConsumer.Data.Records;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RepoEventTypes = AzureDevOpsWebhookConsumer.Common.Constants.RepoEventTypes;

namespace AzureDevOpsWebhookConsumer.Api
{
    public static class AzureDevOpsWebhooksHandlerEndpoints
    {
        public static WebApplication MapAzureDevOpsWebhookRepo(this WebApplication app)
        {
            // Consume Code related webhooks
            app.MapPost("/webhook/repo", async (HttpContext context, AzureDevOpsEventsDb data) =>
            {
                using var reader = new StreamReader(context.Request.Body);
                try
                {
                    var body = await reader.ReadToEndAsync();

                    var model = JsonConvert.DeserializeObject<EventTypeDto>(body);

                    switch (model!.EventType)
                    {
                        case RepoEventTypes.CodePushed:
                            await data.CodePushed.AddAsync(new CodeRecords.CodePushedModel
                            {
                                NotificationJson = body
                            });
                            break;
                        case RepoEventTypes.RepositoryCreated:
                            await data.RepositoryCreated.AddAsync(new CodeRecords.RepositoryCreated
                            {
                                NotificationJson = body
                            });
                            break;
                        case RepoEventTypes.RepositoryDeleted:
                            await data.RepositoryDeleted.AddAsync(new CodeRecords.RepositoryDeleted
                            {
                                NotificationJson = body
                            });
                            break;
                        case RepoEventTypes.RepositoryForked:
                            await data.RepositoryForked.AddAsync(new CodeRecords.RepositoryForked
                            {
                                NotificationJson = body
                            });
                            break;
                        case RepoEventTypes.RepositoryRenamed:
                            await data.RepositoryRenamed.AddAsync(new CodeRecords.RepositoryRenamed
                            {
                                NotificationJson = body
                            });
                            break;
                        case RepoEventTypes.RepositoryStatusChanged:
                            await data.RepositoryStatusChanged.AddAsync(new CodeRecords.RepositoryStatusChanged
                            {
                                NotificationJson = body
                            });
                            break;
                        default:
                            throw new InvalidDataException("Event Type is invalid!");
                    }

                    await data.SaveChangesAsync();

                    return Results.Ok();
                }
                catch (Exception e)
                {
                    await Console.Out.WriteLineAsync(e.Message);
                }
                return Results.BadRequest();
            });

            app.MapGet("/webhook/repo", async (AzureDevOpsEventsDb data) =>
            {
                var codePushed = await data.CodePushed.ToListAsync();
                var repoCreated = await data.RepositoryCreated.ToListAsync();
                var repoDeleted = await data.RepositoryDeleted.ToListAsync();
                var repoForked = await data.RepositoryForked.ToListAsync();
                var repoRenamed = await data.RepositoryRenamed.ToListAsync();
                var repoStatusChanged = await data.RepositoryStatusChanged.ToListAsync();

                return Results.Ok(new
                {
                    codePushed,
                    repoCreated,
                    repoDeleted,
                    repoForked,
                    repoRenamed,
                    repoStatusChanged
                });
            });

            return app;
        }
    }
}
