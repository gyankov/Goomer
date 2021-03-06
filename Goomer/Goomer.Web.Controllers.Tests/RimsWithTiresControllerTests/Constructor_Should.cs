﻿using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
using Goomer.Web.Hubs;
using Goomer.Web.Infrastructure.FileSystem;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Goomer.Web.Controllers.Tests.RimsWithTiresControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateInstanceOfController()
        {
            var mockedRimsWithTiresService = new Mock<IRimsWithTiresService>();
            var mockedFileSaver = new Mock<IFileSaver>();
            var mockedIdentifierProvider = new Mock<IIdentifierProvider>();
            var mockedIStatisticsHubCorresponder = new Mock<IStatisticsHubCorresponder>();
            var mockedIStatisticsService = new Mock<IStatisticsService>();

            var controller = new RimsWithTiresController(
                mockedRimsWithTiresService.Object,
                mockedFileSaver.Object,
                mockedIdentifierProvider.Object,
                mockedIStatisticsHubCorresponder.Object,
                mockedIStatisticsService.Object
                );

            Assert.That(controller, Is.InstanceOf<Controller>());
        }
    }
}
