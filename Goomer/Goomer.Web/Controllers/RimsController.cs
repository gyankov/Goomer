using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Models.Rims;
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
    public class RimsController : Controller
    {
        
        private readonly IRimsService rimsService;
        private readonly IFileSaver fileSaver;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IStatisticsHubCorresponder statisticsHubCorresponder;
        private readonly IStatisticsService statisticsService;
        public RimsController(
            IRimsService rimsService, 
            IFileSaver fileSaver, IIdentifierProvider identifierProvider, 
            IStatisticsHubCorresponder statisticsHubCorresponder,
            IStatisticsService statisticsService)
        {
            this.rimsService = rimsService;
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
        public ActionResult Add(RimViewModel rim, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                return View(rim);
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
            this.rimsService.AddNewTireAd(userId, AutoMapperConfig.Configuration.CreateMapper().Map<Rim>(rim), picturesPaths);            
            this.statisticsHubCorresponder.UpdateAdsCount(this.statisticsService.TotalAds());
            return Redirect("/");
        }

        // [OutputCache(Duration = 60 * 60 * 24, Location = OutputCacheLocation.Any)]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Search(RimsSearchModel rim)
        {
            return RedirectToAction("Searching", rim);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Searching(RimsSearchModel rim)
        {
            var tires = this.rimsService.GetFirstFive(rim).To<ListingRimViewModel>().ToList();
            return View("ListingRim", tires);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SearchingNextFive(RimsSearchModel rim, int page)
        {
            var tires = this.rimsService.GetNextFive(rim, page).To<ListingRimViewModel>().ToList();
            return PartialView("PartialRims", tires);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RimAd(string id)
        {
            var actualId = this.identifierProvider.DecodeId(id);
            var tire = this.rimsService.GetById(actualId);

            return View(AutoMapperConfig.Configuration.CreateMapper().Map<RimAdViewModel>(tire));
        }
        // GET: Rims
        public ActionResult Index()
        {
            var rims = this.rimsService.LatestPosts().To<ListingRimViewModel>().ToList();
            return View("ListingRim", rims);
        }
    }
}