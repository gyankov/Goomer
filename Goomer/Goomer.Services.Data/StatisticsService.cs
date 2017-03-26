using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IDbRepository<Tire> tiresRepo;
        private readonly IDbRepository<Rim> rimsRepo;
        private readonly IDbRepository<RimWithTire> rimsWithTiresRepo;

        public StatisticsService(IDbRepository<Tire> tiresRepo, IDbRepository<Rim> rimsRepo, IDbRepository<RimWithTire> rimsWithTiresRepo)
        {
            this.tiresRepo = tiresRepo;
            this.rimsRepo = rimsRepo;
            this.rimsWithTiresRepo = rimsWithTiresRepo;
        }

        public int TotalAds()
        {
            var totalRimAds = this.rimsRepo.All().Count();
            var totalTireAds = this.tiresRepo.All().Count();
            var totalRimWithTireAds = this.rimsWithTiresRepo.All().Count();

            return totalRimAds + totalRimWithTireAds + totalTireAds;
        }
    }
}
