namespace AzureDevOpsWebhookConsumer.Common
{
    public static class Constants
    {
        public const string DbName = "AzureDevOpsNotifications";
        public static class RepoEventTypes
        {
            public const string CodePushed = "git.push";
            public const string RepositoryCreated = "git.repo.created";
            public const string RepositoryDeleted = "git.repo.deleted";
            public const string RepositoryForked = "git.repo.forked";
            public const string RepositoryRenamed = "git.repo.renamed";
            public const string RepositoryStatusChanged = "git.repo.statuschanged";
        }
    }
}
