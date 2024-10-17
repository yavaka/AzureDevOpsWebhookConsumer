namespace AzureDevOpsWebhookConsumer.Data.Records
{
    public static class CodeRecords
    {
        public record NotificationRecord
        {
            public Guid Id { get; init; }
            public string NotificationJson { get; init; } = default!;
        }

        public record CodePushedModel : NotificationRecord;
        public record RepositoryCreated : NotificationRecord;
        public record RepositoryDeleted : NotificationRecord;
        public record RepositoryForked : NotificationRecord;
        public record RepositoryRenamed : NotificationRecord;
        public record RepositoryStatusChanged : NotificationRecord;
    }
}
