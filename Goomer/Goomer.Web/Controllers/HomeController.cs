using Goomer.Data.Common.Contracts;
using Goomer.Data.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goomer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbRepository<User> usersRepository;
        private readonly IDbRepository<Tire> tiresRepository;
        private readonly IDbRepository<Rim> rimsRepository;
        private readonly IDbRepository<RimWithTire> rimsWithTiresRepository;
        private readonly ICacheService cacheService;

        public HomeController(
            IDbRepository<User> usersRepository, 
            IDbRepository<Tire> tiresRepository,
            IDbRepository<Rim> rimsRepository,
            IDbRepository<RimWithTire> rimsWithTiresRepository,
            ICacheService cacheService)
        {
            this.usersRepository = usersRepository;
            this.tiresRepository = tiresRepository;
            this.rimsRepository = rimsRepository;
            this.rimsWithTiresRepository = rimsWithTiresRepository;
            this.cacheService = cacheService;
        }
        public ActionResult Index()
        {
            //var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<UserViewModel>(User);
            // var users = this.usersRepository.All().To<UserViewModel>().ToList(); 
            var tires = this.cacheService.Get("homeTires", 
                () => this.tiresRepository.All().OrderBy(x => x.CreatedOn).Take(4).To<TireViewModel>().ToList(),
                10 * 60);
            var rims = this.cacheService.Get("homeRims",
              () => this.rimsRepository.All().OrderBy(x => x.CreatedOn).Take(4).To<RimViewModel>().ToList(),
              10 * 60);
            var rimsWithTires = this.cacheService.Get("homeRimsWithTires",
             () => this.rimsWithTiresRepository.All().OrderBy(x => x.CreatedOn).Take(4).To<RimWithTireViewModel>().ToList(),
             10 * 60);
            return View(new HomeViewModel { Rims=rims, RimsWithTires=rimsWithTires,Tires=tires});
        }
    }
}