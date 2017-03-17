using Goomer.Web.Controllers;
using MvcRouteTester;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Goomer.Web.Routes.Tests.BaseRouteTets
{
    [TestFixture]
    public class BaseRoute_Should
    {
        [Test]
        public void CallProperController()
        {
            const string url = "/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url).To<HomeController>(x => x.Index());
        }
    }
}
