using Goomer.Data.Models;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface ITiresService
    {
        IQueryable<Tire> LatestPosts();
    }
}
