using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using System.Linq;
using Goomer.Services.Data.Contracts;
using System.Collections.Generic;
using Goomer.Data.Models.SearchModels;
using System;

namespace Goomer.Services.Data
{
    public class RimsWithTyresService : IRimsWithTiresService
    {
        private readonly IUsersService usersService;
        private readonly IUnitOfWork uow;
        private readonly IDbRepository<RimWithTire> rimWithTireRepo;

        public RimsWithTyresService(IDbRepository<RimWithTire> rimWithTireRepo, IUsersService usersService, IUnitOfWork uow)
        {
            this.rimWithTireRepo = rimWithTireRepo;
            this.usersService = usersService;
            this.uow = uow;
        }

        public RimWithTire GetById(object id)
        {
            return this.rimWithTireRepo.GetById(id);
        }

        public IQueryable<RimWithTire> LatestPosts()
        {
            return this.rimWithTireRepo.All().OrderBy(x => x.CreatedOn).Take(4);
        }

        public void AddNewTireAd(string userId, RimWithTire rimWithTire, IEnumerable<string> picturesPaths)
        {
            var user = this.usersService.GetById(userId);
            rimWithTire.Owner = user;
            this.rimWithTireRepo.Add(rimWithTire);

            foreach (var url in picturesPaths)
            {
                var picture = new RimWithTirePicture { Url = url, RimWithTire = rimWithTire };

                rimWithTire.Pictures.Add(picture);
            }
            this.uow.Commit();
        }

        public IQueryable<RimWithTire> GetNextFive(RimsWithTiresSearchModel searchModel, int page)
        {
            return this.Filter(searchModel).Skip(page * 5).Take(5);
        }

        public IQueryable<RimWithTire> Filter(RimsWithTiresSearchModel searchModel)
        {
            var rimsWithTires = this.rimWithTireRepo.All();

            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                rimsWithTires = rimsWithTires.Where(x => x.Brand.ToLower().Contains(searchModel.Brand.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Model))
            {
                rimsWithTires = rimsWithTires.Where(x => x.Model.ToLower().Contains(searchModel.Model.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Siting))
            {
                rimsWithTires = rimsWithTires.Where(x => x.Siting.ToLower().Contains(searchModel.Siting.ToLower()));
            }

            if (searchModel.DotFrom != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Dot >= searchModel.DotFrom);
            }

            if (searchModel.QuantityFrom != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Quantity >= searchModel.QuantityFrom);
            }

            if (searchModel.Width != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Width == searchModel.Width);
            }

            if (searchModel.Height != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Height == searchModel.Height);
            }

            if (searchModel.Size != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Size == searchModel.Size);
            }

            if (searchModel.PriceFrom != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Price >= searchModel.PriceFrom);
            }

            if (searchModel.PriceTo != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Price <= searchModel.PriceTo);
            }

            if (searchModel.SpeedIndexFrom != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.SpeedIndex >= searchModel.SpeedIndexFrom);
            }

            if (searchModel.WeightIndex != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.WeightIndex == searchModel.WeightIndex);
            }

            if (searchModel.GrappleFrom != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.GrappleMm >= searchModel.GrappleFrom);
            }

            if (searchModel.Season != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.Season == searchModel.Season);
            }

            if (searchModel.OnlyBrandNew)
            {
                rimsWithTires = rimsWithTires.Where(x => x.IsBrandNew);
            }

            if (searchModel.CentralHoleSize != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.CentralHoleSize == searchModel.CentralHoleSize);
            }

            if (searchModel.NumberOfBolts != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.NumberOfBolts == searchModel.NumberOfBolts);
            }

            if (searchModel.SpaceBetweenBolts != null)
            {
                rimsWithTires = rimsWithTires.Where(x => x.SpaceBetweenBolts == searchModel.SpaceBetweenBolts);
            }

            return rimsWithTires.OrderBy(x => x.Brand);
        }

        public IQueryable<RimWithTire> GetFirstFive(RimsWithTiresSearchModel searchModel)
        {
            return this.Filter(searchModel).Take(5);
        }
    }
}
