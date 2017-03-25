using Goomer.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Areas.Administration.Models;

namespace Goomer.Web.Areas.Administration.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService; 
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var users = this.usersService.AllUsers().To<EditUserViewModel>().ToList();
            return this.Json(users.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, EditUserViewModel user)
        {
            if (user != null && this.ModelState.IsValid)
            {
                this.usersService.Update(user.Id,user.IsDeleted,user.Email,user.PhoneNumber,user.IsAdmin);
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        // GET: Administration/Users
        public ActionResult Index()
        {
            var users = this.usersService.AllUsers().To<EditUserViewModel>().ToList();
            return View(users);
        }
    }
}