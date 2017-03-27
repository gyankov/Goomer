using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using System.Collections.Generic;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface IRimsService
    {
        IQueryable<Rim> GetFirstFive(RimsSearchModel searchModel);

        IQueryable<Rim> GetNextFive(RimsSearchModel searchModel, int page);

        IQueryable<Rim> LatestPosts();

        void AddNewTireAd(string userId, Rim rim, IEnumerable<string> picturesPaths);
        
        Rim GetById(object id);
    }
}
