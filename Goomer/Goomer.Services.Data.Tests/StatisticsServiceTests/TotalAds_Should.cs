using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
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
    public class TotalAds_Should
    {
        [Test]
        public void CallTiresRepoAllMethodOnce()
        {
            //Arrange
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedRimsWithTiresRepo = new Mock<IDbRepository<RimWithTire>>();
            var statisticsService = new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, mockedRimsWithTiresRepo.Object);

            var tires = new List<Tire>
            {
                new Tire()
            };

            mockedTiresRepo.Setup(x => x.All()).Returns(tires.AsQueryable());

            var rims = new List<Rim>
            {
                new Rim()
            };

            mockedRimsRepo.Setup(x => x.All()).Returns(rims.AsQueryable());

            var rimsWithTires = new List<RimWithTire>
            {
                new RimWithTire()
            };

            mockedRimsWithTiresRepo.Setup(x => x.All()).Returns(rimsWithTires.AsQueryable());

            //Act
            var count = statisticsService.TotalAds();

            //Assert
            mockedTiresRepo.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void CallRimsRepoAllMethodOnce()
        {
            //Arrange
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedRimsWithTiresRepo = new Mock<IDbRepository<RimWithTire>>();
            var statisticsService = new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, mockedRimsWithTiresRepo.Object);

            var tires = new List<Tire>
            {
                new Tire()
            };

            mockedTiresRepo.Setup(x => x.All()).Returns(tires.AsQueryable());

            var rims = new List<Rim>
            {
                new Rim()
            };

            mockedRimsRepo.Setup(x => x.All()).Returns(rims.AsQueryable());

            var rimsWithTires = new List<RimWithTire>
            {
                new RimWithTire()
            };

            mockedRimsWithTiresRepo.Setup(x => x.All()).Returns(rimsWithTires.AsQueryable());

            //Act
            var count = statisticsService.TotalAds();

            //Assert
            mockedRimsRepo.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void CallRimsWithTiresRepoAllMethodOnce()
        {
            //Arrange
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedRimsWithTiresRepo = new Mock<IDbRepository<RimWithTire>>();
            var statisticsService = new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, mockedRimsWithTiresRepo.Object);

            var tires = new List<Tire>
            {
                new Tire()
            };

            mockedTiresRepo.Setup(x => x.All()).Returns(tires.AsQueryable());

            var rims = new List<Rim>
            {
                new Rim()
            };

            mockedRimsRepo.Setup(x => x.All()).Returns(rims.AsQueryable());

            var rimsWithTires = new List<RimWithTire>
            {
                new RimWithTire()
            };

            mockedRimsWithTiresRepo.Setup(x => x.All()).Returns(rimsWithTires.AsQueryable());

            //Act
            var count = statisticsService.TotalAds();

            //Assert
            mockedRimsWithTiresRepo.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnsCorrectAnswer()
        {
            //Arrange
            var mockedTiresRepo = new Mock<IDbRepository<Tire>>();
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedRimsWithTiresRepo = new Mock<IDbRepository<RimWithTire>>();
            var statisticsService = new StatisticsService(mockedTiresRepo.Object, mockedRimsRepo.Object, mockedRimsWithTiresRepo.Object);

            var tires = new List<Tire>
            {
                new Tire()
            };

            mockedTiresRepo.Setup(x => x.All()).Returns(tires.AsQueryable());

            var rims = new List<Rim>
            {
                new Rim()
            };

            mockedRimsRepo.Setup(x => x.All()).Returns(rims.AsQueryable());

            var rimsWithTires = new List<RimWithTire>
            {
                new RimWithTire()
            };

            mockedRimsWithTiresRepo.Setup(x => x.All()).Returns(rimsWithTires.AsQueryable());

            //Act
            var count = statisticsService.TotalAds();

            //Assert
            Assert.True(count == 3);
        }
    }
}
