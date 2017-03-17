using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Web.Contracts
{
    public interface ICacheService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string itemName);
    }
}
