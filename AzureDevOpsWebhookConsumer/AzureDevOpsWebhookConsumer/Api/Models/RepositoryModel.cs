namespace AzureDevOpsWebhookConsumer.Api.Models
{
    public class RepositoryModel
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Url { get; set; } = default!;
        public ProjectModel Project { get; set; } = default!;
        public string RemoteUrl { get; set; } = default!;
    }
}
