using AzureDevOpsWebhookConsumer.Data;

namespace AzureDevOpsWebhookConsumer.Services.RepoService
{
    public class RepoService(AzureDevOpsEventsDb data)
    {
        private readonly AzureDevOpsEventsDb _data = data;

        //public Task CodePushed(string json)
        //{

        //}
    }
}
