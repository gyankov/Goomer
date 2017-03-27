using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data.Tests.RimsWithTiresServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRimsWithTiresRepoIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RimsWithTyresService(null, null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUsersServiceIsNull()
        {
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();

            Assert.Throws<ArgumentNullException>(() => new RimsWithTyresService(mockedRepo.Object, null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUowIsNull()
        {
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, null));
        }

        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull()
        {
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();

            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            Assert.That(service, Is.Not.Null);
        }


        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull_AndIsInstanceOfIRimsService()
        {
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();

            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            Assert.That(service, Is.InstanceOf<IRimsWithTiresService>());
        }
    }
}
