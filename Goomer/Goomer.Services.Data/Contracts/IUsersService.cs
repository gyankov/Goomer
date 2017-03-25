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

        User GetById(object id);

        bool ChekIfDeleted(string username);

        User GetByUserName(string username);

        void Update(object userId, bool IsDeleted, string Email, string PhoneNumber, bool IsAdmin);
    }
}
