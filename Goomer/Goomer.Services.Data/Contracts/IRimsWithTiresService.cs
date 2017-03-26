using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using System.Collections.Generic;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface IRimsWithTiresService
    {
        IQueryable<RimWithTire> GetFirstFive(RimsWithTiresSearchModel searchModel);

        IQueryable<RimWithTire> GetNextFive(RimsWithTiresSearchModel searchModel, int page);

        IQueryable<RimWithTire> LatestPosts();

        void AddNewTireAd(string userId, RimWithTire rimWithTire, IEnumerable<string> picturesPaths);

        IQueryable<RimWithTire> Filter(RimsWithTiresSearchModel searchModel);

        RimWithTire GetById(object id);
    }
}
