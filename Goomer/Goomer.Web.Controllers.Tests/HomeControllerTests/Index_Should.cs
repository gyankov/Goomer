﻿using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
using Goomer.Services.Web.Contracts;
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
            
        }
    }
}

//var autoMapperConfig = new AutoMapperConfig();
//autoMapperConfig.Execute(typeof(HomeController).Assembly);
//var mockedRepository = new Mock<IDbRepository<User>>();
//var users = new List<User>
//{
//    new User()
//};
//mockedRepository.Setup(x => x.All()).Returns(users.AsQueryable);
//var controller = new HomeController(mockedRepository.Object);

//controller.WithCallTo(x => x.Index()).ShouldRenderView("Index");
////().WithModel method exist you dumb fuck
