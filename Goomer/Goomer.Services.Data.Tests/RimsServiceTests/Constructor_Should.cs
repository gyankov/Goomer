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
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRimsRepoIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RimsService(null, null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUsersServiceIsNull()
        {
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();

            Assert.Throws<ArgumentNullException>(() => new RimsService(mockedRimsRepo.Object, null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUowIsNull()
        {
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, null));
        }

        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull()
        {
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();

            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            Assert.That(service, Is.Not.Null);
        }


        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull_AndIsInstanceOfIRimsService()
        {
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();

            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            Assert.That(service, Is.InstanceOf<IRimsService>());
        }
    }
}
