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
using TestStack.FluentMVCTesting;

namespace Goomer.Web.Controllers.Tests.RimsControllerTests
{
    [TestFixture]
    public class Search_Should
    {
        [Test]
        public void RenderView()
        {
            //Arrange
            var mockedRimsService = new Mock<IRimsService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();

            var controller = new RimsController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.Search()).ShouldRenderView("Search");
        }

        [Test]
        public void RedirectToSearching()
        {
            //Arrange
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RimsController).Assembly);
            var mockedRimsService = new Mock<IRimsService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();
            var mockedSearchModel = new Mock<RimsSearchModel>();

            mockedRimsService.Setup(x => x.GetFirstFive(It.IsAny<RimsSearchModel>())).Returns(new List<Rim>().AsQueryable());

            var controller = new RimsController(
                mockedRimsService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            //Act and Assert
            controller.WithCallTo(x => x.Search(It.IsAny<RimsSearchModel>())).ShouldRedirectTo(x=> x.Searching(It.IsAny<RimsSearchModel>()));
        }
    }
}
