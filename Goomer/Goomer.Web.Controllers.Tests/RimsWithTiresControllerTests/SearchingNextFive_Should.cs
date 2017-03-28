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
    public class SearchingNextFive_Should
    {
        [Test]
        public void CallRimsServiceGetNextFiveMethod()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsService.Setup(x => x.GetNextFive(It.IsAny<RimsWithTiresSearchModel>(), It.IsAny<int>())).Returns(new List<RimWithTire>().AsQueryable());

            var controller = new RimsWithTiresController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.SearchingNextFive(It.IsAny<RimsWithTiresSearchModel>(), It.IsAny<int>());

            //Assert
            mockedRimsService.Verify(x => x.GetNextFive(It.IsAny<RimsWithTiresSearchModel>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void RenderPartialRimsWithProperModel()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsService.Setup(x => x.GetNextFive(It.IsAny<RimsWithTiresSearchModel>(), It.IsAny<int>())).Returns(new List<RimWithTire>().AsQueryable());


            var controller = new RimsWithTiresController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.SearchingNextFive(It.IsAny<RimsWithTiresSearchModel>(), It.IsAny<int>())).ShouldRenderPartialView("PartialRimsWithTires")
                .WithModel<IEnumerable<ListingTireWithRimViewModel>>();
        }
    }
}
