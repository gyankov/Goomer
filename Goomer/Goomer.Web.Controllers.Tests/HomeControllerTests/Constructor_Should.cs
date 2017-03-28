
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Goomer.Web.Controllers.Tests.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstanceOfController()
        {
            var mockedTiresService = new Mock<ITiresService>();
            var mockedRimsService = new Mock<IRimsService>();
            var mockedRimsWithTiresService = new Mock<IRimsWithTiresService>();
            var mockedStatistisService = new Mock<IStatisticsService>();
            var mockedCacheService = new Mock<ICacheService>();

            var controller = new HomeController(
                mockedTiresService.Object,
                mockedRimsService.Object,
                mockedRimsWithTiresService.Object,
                mockedCacheService.Object,
                mockedStatistisService.Object);

            Assert.That(controller, Is.InstanceOf<Controller>());
        }
    }
}
