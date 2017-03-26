using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Models.RimsWithTires;
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
    public class RimsWithTiresController : Controller
    {

        private readonly IUsersService usersService;
        private readonly IRimsWithTiresService rimWithTireService;
        private readonly IFileSaver fileSaver;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IStatisticsHubCorresponder statisticsHubCorresponder;
        private readonly IStatisticsService statisticsService;

        public RimsWithTiresController(
            IUsersService usersService,
            IRimsWithTiresService rimWithTireService,
            IFileSaver fileSaver,
            IIdentifierProvider identifierProvider,
            IStatisticsHubCorresponder statisticsHubCorresponder,
            IStatisticsService statisticsService
            )
        {
            this.usersService = usersService;
            this.rimWithTireService = rimWithTireService;
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
        public ActionResult Add(RimWithTireViewModel rimWithTire, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                return View(rimWithTire);
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
            this.rimWithTireService.AddNewTireAd(userId, AutoMapperConfig.Configuration.CreateMapper().Map<RimWithTire>(rimWithTire), picturesPaths);
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
        public ActionResult Search(RimsWithTiresSearchModel rimWithTire)
        {
            return RedirectToAction("Searching", rimWithTire);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Searching(RimsWithTiresSearchModel rimWithTire)
        {
            var rimsWithTires = this.rimWithTireService.GetFirstFive(rimWithTire).To<ListingTireWithRimViewModel>().ToList();
            return View("ListingRimWithTire", rimsWithTires);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SearchingNextFive(RimsWithTiresSearchModel rim, int page)
        {
            var tires = this.rimWithTireService.GetNextFive(rim, page).To<ListingTireWithRimViewModel>().ToList();
            return PartialView("PartialRimsWithTires", tires);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RimWithTireAd(string id)
        {
            var actualId = this.identifierProvider.DecodeId(id);
            var rimWithTire = this.rimWithTireService.GetById(actualId);

            return View(AutoMapperConfig.Configuration.CreateMapper().Map<RimWithTireAdViewModel>(rimWithTire));
        }

        public ActionResult Index()
        {
            var tires = this.rimWithTireService.LatestPosts().To<ListingTireWithRimViewModel>().ToList();
            return View("ListingRimWithTire", tires);
        }
    }
}