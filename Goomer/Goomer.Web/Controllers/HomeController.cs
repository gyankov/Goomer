using Goomer.Data.Common.Contracts;
using Goomer.Data.Contracts;
using Goomer.Data.Models;
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
        private IDbRepository<User> usersRepository;
        public HomeController(IDbRepository<User> usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public ActionResult Index()
        {
           //var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<UserViewModel>(User);

            var users = this.usersRepository.All().To<UserViewModel>().ToList();
            return View();
        }
    }
}