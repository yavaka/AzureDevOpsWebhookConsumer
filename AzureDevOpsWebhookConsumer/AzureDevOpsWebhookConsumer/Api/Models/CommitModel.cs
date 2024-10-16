namespace AzureDevOpsWebhookConsumer.Api.Models
{
    public class CommitModel
    {
        public string CommitId { get; set; } = default!;
        public AuthorModel Author { get; set; } = default!;
        public AuthorModel Committer { get; set; } = default!;
    }
}
