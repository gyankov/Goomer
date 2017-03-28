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
    class Searching_Should
    {
        [Test]
        public void CallRimsServiceGetFirstFiveMethod()
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

            mockedRimsService.Setup(x => x.GetFirstFive(It.IsAny<TiresSearchModel>())).Returns(new List<Tire>().AsQueryable());

            var controller = new TiresController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.Searching(It.IsAny<TiresSearchModel>());

            // Assert
            mockedRimsService.Verify(x => x.GetFirstFive(It.IsAny<TiresSearchModel>()), Times.Once);
        }

        [Test]
        public void RenderListingRimViewWithModelListingViewModel()
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

            mockedRimsService.Setup(x => x.GetFirstFive(It.IsAny<TiresSearchModel>())).Returns(new List<Tire>().AsQueryable());

            var controller = new TiresController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.Searching(It.IsAny<TiresSearchModel>())).ShouldRenderView("ListingTire").WithModel<IEnumerable<ListingTireViewModel>>();
        }
    }
}
