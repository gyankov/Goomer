using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Hubs
{
    public interface IStatisticsHubCorresponder
    {
        void UpdateAdsCount(int count);
    }
}