using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Models.RimsWithTires;
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

namespace Goomer.Web.Controllers.Tests.RimsWithTiresControllerTests
{
    [TestFixture]
    public class Searching_Should
    {
        [Test]
        public void CallRimsServiceGetFirstFiveMethod()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsWithTiresService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsWithTiresService.Setup(x => x.GetFirstFive(It.IsAny<RimsWithTiresSearchModel>())).Returns(new List<RimWithTire>().AsQueryable());

            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.Searching(It.IsAny<RimsWithTiresSearchModel>());

            // Assert
            mockedRimsWithTiresService.Verify(x => x.GetFirstFive(It.IsAny<RimsWithTiresSearchModel>()), Times.Once);
        }

        [Test]
        public void RenderListingRimViewWithModelListingViewModel()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsWithTiresService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsWithTiresService.Setup(x => x.GetFirstFive(It.IsAny<RimsWithTiresSearchModel>())).Returns(new List<RimWithTire>().AsQueryable());

            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.Searching(It.IsAny<RimsWithTiresSearchModel>())).ShouldRenderView("ListingRimWithTire")
                .WithModel<IEnumerable<ListingTireWithRimViewModel>>();
        }
    }
}
