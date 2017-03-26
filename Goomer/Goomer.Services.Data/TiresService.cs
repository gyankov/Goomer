using Goomer.Services.Data.Contracts;
using System.Linq;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;
using Goomer.Services.Web.Contracts;
using System.Collections;
using System.Collections.Generic;
using System;
using Goomer.Data.Models.SearchModels;

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

        public Tire GetById(object id)
        {
            return this.tiresRepo.GetById(id);
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

        public IQueryable<Tire> GetNextFive(TiresSearchModel searchModel, int page)
        {
            return this.Filter(searchModel).Skip(page * 5).Take(5);
        }

        public IQueryable<Tire> Filter(TiresSearchModel searchModel)
        {
            var tires = this.tiresRepo.All();

            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                tires = tires.Where(x => x.Brand.ToLower().Contains(searchModel.Brand.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Model))
            {
                tires = tires.Where(x => x.Model.ToLower().Contains(searchModel.Model.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Siting))
            {
                tires = tires.Where(x => x.Siting.ToLower().Contains(searchModel.Siting.ToLower()));
            }

            if (searchModel.DotFrom != null)
            {
                tires = tires.Where(x => x.Dot >= searchModel.DotFrom);
            }

            if (searchModel.QuantityFrom != null)
            {
                tires = tires.Where(x => x.Quantity >= searchModel.QuantityFrom);
            }
            
            if (searchModel.Width != null)
            {
                tires = tires.Where(x => x.Width == searchModel.Width);
            }

            if (searchModel.Height != null)
            {
                tires = tires.Where(x => x.Height == searchModel.Height);
            }

            if (searchModel.Size != null)
            {
                tires = tires.Where(x => x.Size == searchModel.Size);
            }

            if (searchModel.PriceFrom != null)
            {
                tires = tires.Where(x => x.Price >= searchModel.PriceFrom);
            }

            if (searchModel.PriceTo != null)
            {
                tires = tires.Where(x => x.Price <= searchModel.PriceTo);
            }

            if (searchModel.SpeedIndexFrom != null)
            {
                tires = tires.Where(x => x.SpeedIndex >= searchModel.SpeedIndexFrom);
            }

            if (searchModel.WeightIndex != null)
            {
                tires = tires.Where(x => x.WeightIndex == searchModel.WeightIndex);
            }

            if (searchModel.GrappleFrom != null)
            {
                tires = tires.Where(x => x.GrappleMm >= searchModel.GrappleFrom);
            }

            if (searchModel.Season != null)
            {
                tires = tires.Where(x => x.Season == searchModel.Season);
            }

            if (searchModel.OnlyBrandNew)
            {
                tires = tires.Where(x => x.IsBrandNew);
            }

            return tires.OrderBy(x=> x.Brand);
        }

        public IQueryable<Tire> GetFirstFive(TiresSearchModel searchModel)
        {
            return this.Filter(searchModel).Take(5);
        }
    }
}
