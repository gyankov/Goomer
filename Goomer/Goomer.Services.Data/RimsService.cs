using Goomer.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;
using Goomer.Services.Web.Contracts;

namespace Goomer.Services.Data
{
    public class RimsService : IRimsService
    {
        private readonly IDbRepository<Rim> rimsRepo;

        public RimsService(IDbRepository<Rim> rimsRepo)
        {
            this.rimsRepo = rimsRepo;
        }

        public IQueryable<Rim> LatestPosts()
        {
            return this.rimsRepo.All().OrderBy(x => x.CreatedOn).Take(4);

        }
    }
}
