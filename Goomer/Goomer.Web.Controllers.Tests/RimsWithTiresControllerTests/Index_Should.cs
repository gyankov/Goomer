﻿using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Infrastructure.FileSystem;
using Goomer.Web.Infrastructure.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goomer.Web.Models.RimsWithTires;
using TestStack.FluentMVCTesting;

namespace Goomer.Web.Controllers.Tests.RimsWithTiresControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallRimsServicesLatestPostMethod()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsWithTiresController).Assembly);
            var mockedRimsWithTiresService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsWithTiresService.Setup(x => x.LatestPosts()).Returns(new List<RimWithTire>().AsQueryable());

            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act
            var result = controller.Index();

            //Assert
            mockedRimsWithTiresService.Verify(x => x.LatestPosts(), Times.Once);
        }

        [Test]
        public void RenderListinRimViewWithListingRimAdViewModel()
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
            controller.WithCallTo(x => x.Index()).ShouldRenderView("ListingRimWithTire").WithModel<IEnumerable<ListingTireWithRimViewModel>>();
        }
    }
}
