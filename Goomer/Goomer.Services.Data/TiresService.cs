using Goomer.Services.Data.Contracts;
using System.Linq;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;
using Goomer.Services.Web.Contracts;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Goomer.Services.Data
{
    public class TiresService : ITiresService
    {
        private readonly IDbRepository<Tire> tiresRepo;
        private readonly IUsersService usersService;
        private readonly IUnitOfWork uow;

        public TiresService(IDbRepository<Tire> tiresRepo, IUsersService usersService, IUnitOfWork uow)
        {
            this.usersService = usersService;
            this.tiresRepo = tiresRepo;
            this.uow = uow;
        }

        public IQueryable<Tire> LatestPosts()
        {
            return this.tiresRepo.All().OrderBy(x => x.CreatedOn).Take(4);

        }

        public void AddNewTireAd(string userId, Tire tire, IEnumerable<string> picturesPaths)
        {
            var user = this.usersService.GetById(userId);
            tire.Owner = user;
            this.tiresRepo.Add(tire);

            foreach (var url in picturesPaths)
            {
                var picture = new TirePicture { Url = url, Tire = tire };
                               
                tire.Pictures.Add(picture);
            }
            this.uow.Commit();
        }
    }
}
