using Goomer.Data.Common.Contracts;
using Goomer.Data.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
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
        private readonly IUsersService usersService;
        private readonly ITiresService tiresService;
        private readonly IRimsService rimsService;
        private readonly IRimsWithTiresService rimsWithTyresService;
        private readonly ICacheService cacheService;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IStatisticsService statisticsService;
        public HomeController(
            IUsersService usersService,
            ITiresService tiresService,
            IRimsService rimsService,
            IRimsWithTiresService rimsWithTyresService,
            ICacheService cacheService,
            IIdentifierProvider identifierProvider,
            IStatisticsService statisticsService)
        {
            this.usersService = usersService;
            this.tiresService = tiresService;
            this.rimsService = rimsService;
            this.rimsWithTyresService = rimsWithTyresService;
            this.cacheService = cacheService;
            this.identifierProvider = identifierProvider;
            this.statisticsService = statisticsService;
        }
        public ActionResult Index()
        {
            //var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<UserViewModel>(User);
            // var users = this.usersRepository.All().To<UserViewModel>().ToList(); 

            var tires = this.cacheService.Get(
                "homeTires",
                () => this.tiresService.LatestPosts().To<TireViewModel>().ToList(),
                10 * 60);

            var rims = this.cacheService.Get(
                "homeRims",
                () => this.rimsService.LatestPosts().To<RimViewModel>().ToList(),
                10 * 60);

            var rimsWithTires = this.cacheService.Get(
                "homeRimsWithTires",
                () => this.rimsWithTyresService.LatestPosts().To<RimWithTireViewModel>().ToList(),
                10 * 60);

            return View(new HomeViewModel { Rims = rims, RimsWithTires = rimsWithTires, Tires = tires , AdsCount = this.statisticsService.TotalAds()});
        }
    }
}