﻿using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data.Tests.RimsServiceTests
{
    public class LatestPosts_Should
    {
        [Test]
        public void CallTheRimsRepoAllMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            var rims = new List<Rim> { new Rim() };
            mockedRimsRepo.Setup(x => x.All()).Returns(rims.AsQueryable());
            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.LatestPosts();

            //assert
            mockedRimsRepo.Verify(x => x.All(), Times.Once);
        }
    }
}
