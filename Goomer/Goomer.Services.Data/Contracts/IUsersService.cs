using Goomer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data.Contracts
{
    public interface IUsersService
    {
        IQueryable<User> AllUsers();
    }
}
