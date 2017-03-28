using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Models.Tires;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Goomer.Web.Controllers.Tests.TiresControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallRimsServicesLatestPostMethod()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsService = new Mock<ITiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsService.Setup(x => x.LatestPosts()).Returns(new List<Tire>().AsQueryable());

            var controller = new TiresController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.Index();

            //Assert
            mockedRimsService.Verify(x => x.LatestPosts(), Times.Once);
        }

        [Test]
        public void RenderListinRimViewWithListingRimAdViewModel()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsService = new Mock<ITiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsService.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Tire());

            var controller = new TiresController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderView("ListingTire").WithModel<IEnumerable<ListingTireViewModel>>();
        }
    }
}
