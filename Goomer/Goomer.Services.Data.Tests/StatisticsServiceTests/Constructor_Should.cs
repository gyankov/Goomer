using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Services.Data;
using Goomer.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data.Tests.StatisticsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTiresRepoIsNull()
        {            
            Assert.Throws<ArgumentNullException>(() => new StatisticsService(null,null,null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRimsRepoIsNull()
        {
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();

            Assert.Throws<ArgumentNullException>(() => new StatisticsService(mockedTiresRepo.Object, null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRimsWithTiresRepoIsNull()
        {
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();

            Assert.Throws<ArgumentNullException>(() => new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, null));
        }

        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull()
        {
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedRimsWithTiresRepo = new Mock<IDbRepository<RimWithTire>>();

            var statisticsService = new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, mockedRimsWithTiresRepo.Object);

            Assert.That(statisticsService, Is.Not.Null);
        }

        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull_AndBeInstanceOfIStatisticsService()
        {
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedRimsWithTiresRepo = new Mock<IDbRepository<RimWithTire>>();

            var statisticsService = new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, mockedRimsWithTiresRepo.Object);

            Assert.That(statisticsService, Is.InstanceOf<IStatisticsService>());
        }
    }
}
