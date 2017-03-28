using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Goomer.Web.Models.RimsWithTires;
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
    public class RimWithTireAd_Should
    {
        [Test]
        public void CallIdentifierProvidersDecodeIdMethod()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsWithTiresService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsWithTiresSearchModel>();

            mockedIdentifierProvider.Setup(x => x.DecodeId(It.IsAny<string>())).Returns(It.IsAny<int>());
            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.RimWithTireAd(It.IsAny<string>());

            //Assert
            mockedIdentifierProvider.Verify(x => x.DecodeId(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallRimsServiceGetByIdMethod()
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

            mockedIdentifierProvider.Setup(x => x.DecodeId(It.IsAny<string>())).Returns(It.IsAny<int>());
            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.RimWithTireAd(It.IsAny<string>());

            //Assert
            mockedRimsWithTiresService.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void RenderRimAdViewWithRimAdViewModel()
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

            mockedRimsWithTiresService.Setup(x => x.GetById(It.IsAny<object>())).Returns(new RimWithTire());

            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.RimWithTireAd(It.IsAny<string>())).ShouldRenderView("RimWithTireAd").WithModel<RimWithTireAdViewModel>();
        }
    }
}
