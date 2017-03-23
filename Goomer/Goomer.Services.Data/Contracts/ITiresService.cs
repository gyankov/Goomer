using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using System.Collections.Generic;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface ITiresService
    {
        IQueryable<Tire> LatestPosts();

        void AddNewTireAd(string userId, Tire tire, IEnumerable<string> picturesPaths);

        IQueryable<Tire> Filter(TiresSearchModel searchModel);

        Tire GetById(object id);
    }
}
