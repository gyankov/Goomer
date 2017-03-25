using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goomer.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Error500");
        }

        public ActionResult NotFound()
        {
            return View("Error404");
        }

        public ActionResult ServerError()
        {
            return View("Error500");
        }
    }
}