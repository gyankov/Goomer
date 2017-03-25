using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goomer.Web.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        // GET: Administration/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}