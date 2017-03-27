using Goomer.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;
using Goomer.Data.Models.SearchModels;

namespace Goomer.Services.Data
{
    public class RimsService : IRimsService
    {
        private readonly IDbRepository<Rim> rimsRepo;
        private readonly IUsersService usersService;
        private readonly IUnitOfWork uow;

        public RimsService(IDbRepository<Rim> rimsRepo, IUsersService usersService, IUnitOfWork uow)
        {
            if (rimsRepo == null)
            {
                throw new ArgumentNullException(nameof(rimsRepo));
            }

            if (usersService == null)
            {
                throw new ArgumentNullException(nameof(usersService));
            }

            if (uow == null)
            {
                throw new ArgumentNullException(nameof(uow));
            }
            
            this.rimsRepo = rimsRepo;
            this.usersService = usersService;
            this.uow = uow;
        }

        public Rim GetById(object id)
        {
            return this.rimsRepo.GetById(id);
        }

        public void AddNewTireAd(string userId, Rim rim, IEnumerable<string> picturesPaths)
        {
            var user = this.usersService.GetById(userId);
            rim.Owner = user;
            this.rimsRepo.Add(rim);

            foreach (var url in picturesPaths)
            {
                var picture = new RimPicture { Url = url, Rim = rim };

                rim.Pictures.Add(picture);
            }
            this.uow.Commit();
        }

        public IQueryable<Rim> LatestPosts()
        {
            return this.rimsRepo.All().OrderBy(x => x.CreatedOn).Take(4);

        }

        public IQueryable<Rim> GetNextFive(RimsSearchModel searchModel, int page)
        {
            return this.Filter(searchModel).Skip(page * 5).Take(5);
        }

        public IQueryable<Rim> GetFirstFive(RimsSearchModel searchModel)
        {
            return this.Filter(searchModel).Take(5);
        }

        private IQueryable<Rim> Filter(RimsSearchModel searchModel)
        {
            var rims = this.rimsRepo.All();
            
            return this.BrandFilter(searchModel,rims).OrderBy(x => x.Brand);
        }

        private IQueryable<Rim> BrandFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                rims = rims.Where(x => x.Brand.ToLower().Contains(searchModel.Brand.ToLower()));
            }

            return this.ModelFilter(searchModel, rims);
        }

        private IQueryable<Rim> ModelFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Model))
            {
                rims = rims.Where(x => x.Model.ToLower().Contains(searchModel.Model.ToLower()));
            }

            return this.SitingFilter(searchModel, rims);
        }

        private IQueryable<Rim> SitingFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Siting))
            {
                rims = rims.Where(x => x.Siting.ToLower().Contains(searchModel.Siting.ToLower()));
            }

            return this.QuantityFromFilter(searchModel, rims);
        }

        private IQueryable<Rim> QuantityFromFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.QuantityFrom != null)
            {
                rims = rims.Where(x => x.Quantity >= searchModel.QuantityFrom);
            }

            return this.WidthFilter(searchModel,rims);
        }

        private IQueryable<Rim> WidthFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.Width != null)
            {
                rims = rims.Where(x => x.Width == searchModel.Width);
            }

            return this.CentralHoleSizeFilter(searchModel,rims);
        }

        private IQueryable<Rim> CentralHoleSizeFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.CentralHoleSize != null)
            {
                rims = rims.Where(x => x.CentralHoleSize == searchModel.CentralHoleSize);
            }
            return this.NumberOfBoltsFilter(searchModel,rims);
        }

        private IQueryable<Rim> NumberOfBoltsFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.NumberOfBolts != null)
            {
                rims = rims.Where(x => x.NumberOfBolts == searchModel.NumberOfBolts);
            }

            return this.SpaceBetweenBoltsFilter(searchModel,rims);
        }

        private IQueryable<Rim> SpaceBetweenBoltsFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.SpaceBetweenBolts != null)
            {
                rims = rims.Where(x => x.SpaceBetweenBolts == searchModel.SpaceBetweenBolts);
            }

            return this.SizeFilter(searchModel,rims);
        }

        private IQueryable<Rim> SizeFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.Size != null)
            {
                rims = rims.Where(x => x.Size == searchModel.Size);
            }

            return this.PriceFromFilter(searchModel,rims);
        }

        private IQueryable<Rim> PriceFromFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.PriceFrom != null)
            {
                rims = rims.Where(x => x.Price >= searchModel.PriceFrom);
            }

            return this.PriceToFilter(searchModel,rims);
        }

        private IQueryable<Rim> PriceToFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.PriceTo != null)
            {
                rims = rims.Where(x => x.Price <= searchModel.PriceTo);
            }

            return this.OnlyBrandNewFilter(searchModel,rims);
        }

        private IQueryable<Rim> OnlyBrandNewFilter(RimsSearchModel searchModel, IQueryable<Rim> rims)
        {
            if (searchModel.OnlyBrandNew)
            {
                rims = rims.Where(x => x.IsBrandNew);
            }

            return rims;
        }
    }
}
