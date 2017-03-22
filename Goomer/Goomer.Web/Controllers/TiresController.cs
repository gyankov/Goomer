using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Models.Tires;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goomer.Web.Controllers
{
    [Authorize]
    public class TiresController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ITiresService tiresService;
        private readonly IFileSaver fileSaver;

        public TiresController(IUsersService usersService, ITiresService tiresService, IFileSaver fileSaver)
        {
            this.usersService = usersService;
            this.tiresService = tiresService;
            this.fileSaver = fileSaver;
        }

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
            var actualTire = AutoMapperConfig.Configuration.CreateMapper().Map<Tire>(tire);
            var picturesPaths = new List<string>();
            var counter = 0;
            foreach (var file in files)
            {
                if (counter++ > 6)
                {
                    break;
                }
                var path = DateTime.Now.Ticks.ToString() + file.FileName;
                picturesPaths.Add("/Content/Gallery/" + path);
                fileSaver.SaveFile("/Content/Gallery/" + path, file.InputStream);
            }
            this.tiresService.AddNewTireAd(userId, actualTire, picturesPaths);
            return Redirect("/");
        }

        // GET: Tires
        public ActionResult Index()
        {
            return View();
        }
    }
}