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
            if (rimWithTireRepo == null)
            {
                throw new ArgumentNullException(nameof(rimWithTireRepo));
            }

            if (usersService == null)
            {
                throw new ArgumentNullException(nameof(usersService));
            }

            if (uow == null)
            {
                throw new ArgumentNullException(nameof(uow));
            }

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

        public IQueryable<RimWithTire> GetFirstFive(RimsWithTiresSearchModel searchModel)
        {
            return this.Filter(searchModel).Take(5);
        }

        private IQueryable<RimWithTire> Filter(RimsWithTiresSearchModel searchModel)
        {
            var rimsWithTires = this.rimWithTireRepo.All();
            
            return this.DotFromFilter(searchModel, rimsWithTires).OrderBy(x => x.Brand);
        }
        private IQueryable<RimWithTire> DotFromFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.DotFrom != null)
            {
                rims = rims.Where(x => x.Dot >= searchModel.DotFrom);
            }

            return this.SpeedIndexFilter(searchModel, rims);
        }


        private IQueryable<RimWithTire> SpeedIndexFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.SpeedIndexFrom != null)
            {
                rims = rims.Where(x => x.SpeedIndex >= searchModel.SpeedIndexFrom);
            }

            return this.WeightIndexFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> WeightIndexFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.WeightIndex != null)
            {
                rims = rims.Where(x => x.WeightIndex == searchModel.WeightIndex);
            }

            return this.GrappleMmFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> GrappleMmFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.GrappleFrom != null)
            {
                rims = rims.Where(x => x.GrappleMm >= searchModel.GrappleFrom);
            }

            return this.SeasonFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> SeasonFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.Season != null)
            {
                rims = rims.Where(x => x.Season == searchModel.Season);
            }
            return this.BrandFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> BrandFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                rims = rims.Where(x => x.Brand.ToLower().Contains(searchModel.Brand.ToLower()));
            }

            return this.ModelFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> ModelFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Model))
            {
                rims = rims.Where(x => x.Model.ToLower().Contains(searchModel.Model.ToLower()));
            }

            return this.SitingFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> SitingFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Siting))
            {
                rims = rims.Where(x => x.Siting.ToLower().Contains(searchModel.Siting.ToLower()));
            }

            return this.QuantityFromFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> QuantityFromFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.QuantityFrom != null)
            {
                rims = rims.Where(x => x.Quantity >= searchModel.QuantityFrom);
            }

            return this.WidthFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> WidthFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.Width != null)
            {
                rims = rims.Where(x => x.Width == searchModel.Width);
            }

            return this.CentralHoleSizeFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> CentralHoleSizeFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.CentralHoleSize != null)
            {
                rims = rims.Where(x => x.CentralHoleSize == searchModel.CentralHoleSize);
            }
            return this.NumberOfBoltsFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> NumberOfBoltsFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.NumberOfBolts != null)
            {
                rims = rims.Where(x => x.NumberOfBolts == searchModel.NumberOfBolts);
            }

            return this.SpaceBetweenBoltsFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> SpaceBetweenBoltsFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.SpaceBetweenBolts != null)
            {
                rims = rims.Where(x => x.SpaceBetweenBolts == searchModel.SpaceBetweenBolts);
            }

            return this.SizeFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> SizeFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.Size != null)
            {
                rims = rims.Where(x => x.Size == searchModel.Size);
            }

            return this.PriceFromFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> PriceFromFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.PriceFrom != null)
            {
                rims = rims.Where(x => x.Price >= searchModel.PriceFrom);
            }

            return this.PriceToFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> PriceToFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.PriceTo != null)
            {
                rims = rims.Where(x => x.Price <= searchModel.PriceTo);
            }

            return this.OnlyBrandNewFilter(searchModel, rims);
        }

        private IQueryable<RimWithTire> OnlyBrandNewFilter(RimsWithTiresSearchModel searchModel, IQueryable<RimWithTire> rims)
        {
            if (searchModel.OnlyBrandNew)
            {
                rims = rims.Where(x => x.IsBrandNew);
            }

            return rims;
        }

    }
}
