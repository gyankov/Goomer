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
        private readonly IUnitOfWork uow;

        public UsersService(IDbRepository<User> usersRepo, IUnitOfWork uow)
        {
            this.usersRepo = usersRepo;
            this.uow = uow;
        }

        public IQueryable<User> AllUsers()
        {
            return this.usersRepo.All();
        }

        public User GetById(object id)
        {
            return this.usersRepo.GetById(id);
        }

        public bool ChekIfDeleted(string username)
        {

            return this.GetByUserName(username).IsDeleted;
        }

        public User GetByUserName(string username)
        {
            var user = this.usersRepo.All().Where(x => x.UserName == username).FirstOrDefault();
            return user;
        }

        public void Update(object userId, bool IsDeleted, string Email, string PhoneNumber, bool IsAdmin)
        {
            var user = this.usersRepo.GetById(userId);

            if (user == null)
            {
                throw new ArgumentNullException("User doesn't exist.");
            }

            user.IsDeleted = IsDeleted;
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            user.IsAdmin = IsAdmin;
            user.SetAdmin();

            this.usersRepo.Update(user);
            this.uow.Commit();
        }
    }
}
