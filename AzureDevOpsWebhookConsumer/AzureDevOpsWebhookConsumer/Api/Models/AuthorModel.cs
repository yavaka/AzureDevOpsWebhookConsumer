namespace AzureDevOpsWebhookConsumer.Api.Models
{
    public class AuthorModel
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime Date { get; set; }
    }
}
