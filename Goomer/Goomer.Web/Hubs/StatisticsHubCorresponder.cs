using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Hubs
{
    public class StatisticsHubCorresponder : IStatisticsHubCorresponder
    {
        public void UpdateAdsCount(int count)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();
            hubContext.Clients.All.updateAdsCount(count);
        }
        
    }
}