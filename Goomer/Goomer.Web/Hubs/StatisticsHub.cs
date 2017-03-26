using Microsoft.AspNet.SignalR;

namespace Goomer.Web.Hubs
{
    public class StatisticsHub : Hub
    {
        public void UpdateAdsCount(int count)
        {
            Clients.All().updateAdsCount(count);
        }
    }
}