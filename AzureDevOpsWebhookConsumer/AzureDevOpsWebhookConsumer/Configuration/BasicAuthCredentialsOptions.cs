namespace AzureDevOpsWebhookConsumer.Configuration
{
    public class BasicAuthCredentialsOptions
    {
        public const string BasicAuthCredentials = "BasicAuthCredentials";

        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
