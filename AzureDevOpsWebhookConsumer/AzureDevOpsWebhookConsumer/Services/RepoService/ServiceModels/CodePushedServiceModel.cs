namespace AzureDevOpsWebhookConsumer.Services.RepoService.ServiceModels
{
    public class CodePushedServiceModel
    {
        public int Id { get; set; }
        public string RepositoryName { get; set; } = default!;
        public string RepositoryUrl { get; set; } = default!;
    }
}
