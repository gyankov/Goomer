using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Infrastructure.FileSystem;
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

        private readonly IUsersService usersService;
        private readonly IRimsService rimsService;
        private readonly IFileSaver fileSaver;
        private readonly IIdentifierProvider identifierProvider;
        public RimsController(IUsersService usersService, IRimsService rimsService, IFileSaver fileSaver, IIdentifierProvider identifierProvider)
        {
            this.usersService = usersService;
            this.rimsService = rimsService;
            this.fileSaver = fileSaver;
            this.identifierProvider = identifierProvider;
        }

        [OutputCache(Duration = 60 * 60 * 24, Location = OutputCacheLocation.Any)]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        // GET: Rims
        public ActionResult Index()
        {
            return View();
        }
    }
}