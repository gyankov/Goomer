using Goomer.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goomer.Data.Models;
using Goomer.Data.Common.Contracts;
using Goomer.Services.Web.Contracts;
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

        public IQueryable<Rim> Filter(RimsSearchModel searchModel)
        {
            var rims = this.rimsRepo.All();

            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                rims = rims.Where(x => x.Brand.ToLower().Contains(searchModel.Brand.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Model))
            {
                rims = rims.Where(x => x.Model.ToLower().Contains(searchModel.Model.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Siting))
            {
                rims = rims.Where(x => x.Siting.ToLower().Contains(searchModel.Siting.ToLower()));
            }
            
            if (searchModel.QuantityFrom != null)
            {
                rims = rims.Where(x => x.Quantity >= searchModel.QuantityFrom);
            }
            
            if (searchModel.Width != null)
            {
                rims = rims.Where(x => x.Width == searchModel.Width);
            }

            if (searchModel.CentralHoleSize != null)
            {
                rims = rims.Where(x => x.CentralHoleSize == searchModel.CentralHoleSize);
            }

            if (searchModel.NumberOfBolts != null)
            {
                rims = rims.Where(x => x.NumberOfBolts == searchModel.NumberOfBolts);
            }

            if (searchModel.SpaceBetweenBolts != null)
            {
                rims = rims.Where(x => x.SpaceBetweenBolts == searchModel.SpaceBetweenBolts);
            }

            if (searchModel.Size != null)
            {
                rims = rims.Where(x => x.Size == searchModel.Size);
            }

            if (searchModel.PriceFrom != null)
            {
                rims = rims.Where(x => x.Price >= searchModel.PriceFrom);
            }

            if (searchModel.PriceTo != null)
            {
                rims = rims.Where(x => x.Price <= searchModel.PriceTo);
            }

            if (searchModel.OnlyBrandNew)
            {
                rims = rims.Where(x => x.IsBrandNew);
            }

            return rims;
        }
    }
}
