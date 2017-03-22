using Goomer.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface ITiresService
    {
        IQueryable<Tire> LatestPosts();

        void AddNewTireAd(string userId, Tire tire, IEnumerable<string> picturesPaths);
    }
}
