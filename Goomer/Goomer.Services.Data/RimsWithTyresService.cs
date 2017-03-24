using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using System.Linq;
using Goomer.Services.Data.Contracts;

namespace Goomer.Services.Data
{
    public class RimsWithTyresService : IRimsWithTiresService
    {
        private readonly IDbRepository<RimWithTire> rimWithTireRepo;

        public RimsWithTyresService(IDbRepository<RimWithTire> rimWithTireRepo)
        {
            this.rimWithTireRepo = rimWithTireRepo;
        }

        public RimWithTire GetById(object id)
        {
            return this.rimWithTireRepo.GetById(id);
        }

        public IQueryable<RimWithTire> LatestPosts()
        {
            return this.rimWithTireRepo.All().OrderBy(x => x.CreatedOn).Take(4);
        }
    }
}
