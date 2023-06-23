using Microsoft.EntityFrameworkCore;
using Scrutz.Data;

namespace Scrutz.Model
{
    public class CampaignStatusUpdateService : BackgroundService
    {
        private readonly IServiceProvider services;
        private readonly TimeSpan checkInterval = TimeSpan.FromMinutes(30);

        public CampaignStatusUpdateService(IServiceProvider services)
        {
            this.services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ScrutzContext>();
                    var campaigns = await dbContext.Campaigns.ToListAsync();
                    

                    UpdateCampaignStatuses(campaigns, dbContext);
                }

                await Task.Delay(checkInterval, stoppingToken);
            }
        }

        private void UpdateCampaignStatuses(List<Campaign> campaigns, ScrutzContext dbContext)
        {
            foreach (var campaign in campaigns)
            {
                if (campaign.EndDate != null && campaign.EndDate <= DateTime.Now)
                {
                    campaign.CampaignStatus = ActiveStatus.InActive;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
