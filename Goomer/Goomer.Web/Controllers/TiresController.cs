using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Models.Tires;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Goomer.Web.Controllers
{
    [Authorize]
    public class TiresController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ITiresService tiresService;
        private readonly IFileSaver fileSaver;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IStatisticsHubCorresponder statisticsHubCorresponder;
        private readonly IStatisticsService statisticsService;

        public TiresController(
            IUsersService usersService,
            ITiresService tiresService,
            IFileSaver fileSaver,
            IIdentifierProvider identifierProvider,
            IStatisticsHubCorresponder statisticsHubCorresponder,
            IStatisticsService statisticsService
            )
        {
            this.usersService = usersService;
            this.tiresService = tiresService;
            this.fileSaver = fileSaver;
            this.identifierProvider = identifierProvider;
            this.statisticsHubCorresponder = statisticsHubCorresponder;
            this.statisticsService = statisticsService;
        }
        [OutputCache(Duration = 60 * 60 * 24, Location = OutputCacheLocation.Any)]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TireViewModel tire, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                return View(tire);
            }
            var userId = this.User.Identity.GetUserId();
            var picturesPaths = new List<string>();
            var counter = 0;
            foreach (var file in files)
            {
                if (counter++ > 3)
                {
                    break;
                }
                var path = DateTime.Now.Ticks.ToString() + file.FileName;
                picturesPaths.Add("/Content/Gallery/" + path);
                fileSaver.SaveFile("/Content/Gallery/" + path, file.InputStream);
            }
            this.tiresService.AddNewTireAd(userId, AutoMapperConfig.Configuration.CreateMapper().Map<Tire>(tire), picturesPaths);
            this.statisticsHubCorresponder.UpdateAdsCount(this.statisticsService.TotalAds());
            return Redirect("/");
        }

        [OutputCache(Duration = 60 * 60 * 24, Location = OutputCacheLocation.Any)]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Search(TiresSearchModel tire)
        {
            return RedirectToAction("Searching", tire);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Searching(TiresSearchModel tire)
        {
            var tires = this.tiresService.GetFirstFive(tire).To<ListingTireViewModel>().ToList();
            return View("ListingTire", tires);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SearchingNextFive(TiresSearchModel rim, int page)
        {
            var tires = this.tiresService.GetNextFive(rim, page).To<ListingTireViewModel>().ToList();
            return PartialView("PartialTires", tires);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult TireAd(string id)
        {
            var actualId = this.identifierProvider.DecodeId(id);
            var tire = this.tiresService.GetById(actualId);

            return View(AutoMapperConfig.Configuration.CreateMapper().Map<TireAdViewModel>(tire));
        }

        public ActionResult Index()
        {
            var tires = this.tiresService.LatestPosts().To<ListingTireViewModel>().ToList();
            return View("ListingTire", tires);
        }
    }
}