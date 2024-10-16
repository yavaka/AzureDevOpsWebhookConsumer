using Microsoft.EntityFrameworkCore;

namespace AzureDevOpsWebhookConsumer.Data
{
    public class AzureDevOpsEventsDb : DbContext
    {
        public AzureDevOpsEventsDb(DbContextOptions<AzureDevOpsEventsDb> options)
            :base(options) { }


    }
}
