using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Web.Controllers;
using Goomer.Web.Infrastructure.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Goomer.Web.Controllers.Tests.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void WorkProperly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(HomeController).Assembly);
            var mockedRepository = new Mock<IDbRepository<User>>();
            var users = new List<User>
            {
                new User()
            };
            mockedRepository.Setup(x => x.All()).Returns(users.AsQueryable);
            var controller = new HomeController(mockedRepository.Object);

            controller.WithCallTo(x => x.Index()).ShouldRenderView("Index");
            //().WithModel method exist you dumb fuck
        }
    }
}
