using static AzureDevOpsWebhookConsumer.Api.AzureDevOpsWebhooksHandlerEndpoints;

namespace AzureDevOpsWebhookConsumer.Api.Models
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public string Id { get; set; } = default!;
        public MessageModel Message { get; set; } = default!;
        public MessageModel DetailedMessage { get; set; } = default!;
        public ResourceModel Resource { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
    }
}
