using Goomer.Data.Models;
using System.Linq;

namespace Goomer.Services.Data.Contracts
{
    public interface IRimsWithTiresService
    {
        IQueryable<RimWithTire> LatestPosts();
    }
}
