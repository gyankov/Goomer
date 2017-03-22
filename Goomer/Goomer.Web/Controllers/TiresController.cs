using Goomer.Web.Models.Tires;
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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TireViewModel tire, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var item in files)
            {

            }
            return View();
        }
        // GET: Tires
        public ActionResult Index()
        {
            return View();
        }
    }
}