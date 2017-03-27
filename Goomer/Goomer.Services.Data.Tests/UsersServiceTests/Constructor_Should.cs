using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data.Tests.UsersServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepoIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UsersService(null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUowIsNull()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();

            Assert.Throws<ArgumentNullException>(() => new UsersService(mockedRepo.Object, null));
        }

        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();

            var service = new UsersService(mockedRepo.Object, mockedUow.Object);

            Assert.That(service, Is.Not.Null);
        }


        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull_AndIsInstanceOfIUsersService()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();

            var service = new UsersService(mockedRepo.Object, mockedUow.Object);

            Assert.That(service, Is.InstanceOf<IUsersService>());
        }
    }
}
