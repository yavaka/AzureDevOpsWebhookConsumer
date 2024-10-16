namespace AzureDevOpsWebhookConsumer.Api.Models
{
    public class ResourceModel
    {
        public string Url { get; set; } = default!;
        public DateTime Date { get; set; }
        public RepositoryModel Repository { get; set; } = default!;
        public List<CommitModel> Commits { get; set; } = default!;
    }
}
