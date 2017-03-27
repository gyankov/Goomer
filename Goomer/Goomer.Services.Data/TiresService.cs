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
            if (tiresRepo == null)
            {
                throw new ArgumentNullException(nameof(tiresRepo));
            }

            if (usersService == null)
            {
                throw new ArgumentNullException(nameof(usersService));
            }

            if (uow == null)
            {
                throw new ArgumentNullException(nameof(uow));
            }

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

        public IQueryable<Tire> GetFirstFive(TiresSearchModel searchModel)
        {
            return this.Filter(searchModel).Take(5);
        }

        private IQueryable<Tire> Filter(TiresSearchModel searchModel)
        {
            var tires = this.tiresRepo.All();
            
            return this.DotFromFilter(searchModel,tires).OrderBy(x=> x.Brand);
        }
        private IQueryable<Tire> DotFromFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.DotFrom != null)
            {
                rims = rims.Where(x => x.Dot >= searchModel.DotFrom);
            }

            return this.SpeedIndexFilter(searchModel, rims);
        }


        private IQueryable<Tire> SpeedIndexFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.SpeedIndexFrom != null)
            {
                rims = rims.Where(x => x.SpeedIndex >= searchModel.SpeedIndexFrom);
            }

            return this.WeightIndexFilter(searchModel, rims);
        }

        private IQueryable<Tire> WeightIndexFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.WeightIndex != null)
            {
                rims = rims.Where(x => x.WeightIndex == searchModel.WeightIndex);
            }

            return this.GrappleMmFilter(searchModel, rims);
        }

        private IQueryable<Tire> GrappleMmFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.GrappleFrom != null)
            {
                rims = rims.Where(x => x.GrappleMm >= searchModel.GrappleFrom);
            }

            return this.SeasonFilter(searchModel, rims);
        }

        private IQueryable<Tire> SeasonFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.Season != null)
            {
                rims = rims.Where(x => x.Season == searchModel.Season);
            }
            return this.BrandFilter(searchModel, rims);
        }

        private IQueryable<Tire> BrandFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                rims = rims.Where(x => x.Brand.ToLower().Contains(searchModel.Brand.ToLower()));
            }

            return this.ModelFilter(searchModel, rims);
        }

        private IQueryable<Tire> ModelFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Model))
            {
                rims = rims.Where(x => x.Model.ToLower().Contains(searchModel.Model.ToLower()));
            }

            return this.SitingFilter(searchModel, rims);
        }

        private IQueryable<Tire> SitingFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Siting))
            {
                rims = rims.Where(x => x.Siting.ToLower().Contains(searchModel.Siting.ToLower()));
            }

            return this.QuantityFromFilter(searchModel, rims);
        }

        private IQueryable<Tire> QuantityFromFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.QuantityFrom != null)
            {
                rims = rims.Where(x => x.Quantity >= searchModel.QuantityFrom);
            }

            return this.WidthFilter(searchModel, rims);
        }

        private IQueryable<Tire> WidthFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.Width != null)
            {
                rims = rims.Where(x => x.Width == searchModel.Width);
            }

            return this.SizeFilter(searchModel, rims);
        }
        
        private IQueryable<Tire> SizeFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.Size != null)
            {
                rims = rims.Where(x => x.Size == searchModel.Size);
            }

            return this.PriceFromFilter(searchModel, rims);
        }

        private IQueryable<Tire> PriceFromFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.PriceFrom != null)
            {
                rims = rims.Where(x => x.Price >= searchModel.PriceFrom);
            }

            return this.PriceToFilter(searchModel, rims);
        }

        private IQueryable<Tire> PriceToFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.PriceTo != null)
            {
                rims = rims.Where(x => x.Price <= searchModel.PriceTo);
            }

            return this.OnlyBrandNewFilter(searchModel, rims);
        }

        private IQueryable<Tire> OnlyBrandNewFilter(TiresSearchModel searchModel, IQueryable<Tire> rims)
        {
            if (searchModel.OnlyBrandNew)
            {
                rims = rims.Where(x => x.IsBrandNew);
            }

            return rims;
        }


    }
}
