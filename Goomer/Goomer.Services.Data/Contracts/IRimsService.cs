using Goomer.Data.Models;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface IRimsService
    {
        IQueryable<Rim> LatestPosts();
    }
}
