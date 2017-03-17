using Goomer.Services.Data.Contracts;
using System;
using System.Linq;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;

namespace Goomer.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> usersRepo;

        public UsersService(IDbRepository<User> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        public IQueryable<User> AllUsers()
        {
            return this.usersRepo.All();
        }
    }
}
