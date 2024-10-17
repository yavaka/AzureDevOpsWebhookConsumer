using AzureDevOpsWebhookConsumer.Data.Records;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AzureDevOpsWebhookConsumer.Data
{
    public class AzureDevOpsEventsDb(DbContextOptions<AzureDevOpsEventsDb> options) : DbContext(options)
    {
        public DbSet<CodeRecords.CodePushedModel> CodePushed { get; set; }
        public DbSet<CodeRecords.RepositoryCreated> RepositoryCreated { get; set; }
        public DbSet<CodeRecords.RepositoryDeleted> RepositoryDeleted { get; set; }
        public DbSet<CodeRecords.RepositoryForked> RepositoryForked { get; set; }
        public DbSet<CodeRecords.RepositoryRenamed> RepositoryRenamed { get; set; }
        public DbSet<CodeRecords.RepositoryStatusChanged> RepositoryStatusChanged { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(message => Debug.WriteLine(message));
    }
}
