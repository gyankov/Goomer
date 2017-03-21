using Goomer.Services.Data.Contracts;
using System.Linq;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;
using Goomer.Services.Web.Contracts;

namespace Goomer.Services.Data
{
    public class TiresService : ITiresService
    {
        private readonly IDbRepository<Tire> tiresRepo;
        public TiresService(IDbRepository<Tire> tiresRepo, ICacheService cacheService)
        {
            this.tiresRepo = tiresRepo;

        }

        public IQueryable<Tire> LatestPosts()
        {
            return this.tiresRepo.All().OrderBy(x => x.CreatedOn).Take(4);

        }
    }
}
