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

namespace Goomer.Services.Data.Tests.TiresServiceTests
{
    public class AddNewTireAd_Should
    {
        [Test]
        public void CallTheUsersServiceGetByIdMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<Tire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Tire());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<Tire>();
            var pics = new List<TirePicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new TiresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedUsersService.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void CallTheRimsRepoAddIdMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Tire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRimsRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Tire());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<Tire>();
            var pics = new List<TirePicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new TiresService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedRimsRepo.Verify(x => x.Add(It.IsAny<Tire>()), Times.Once);
        }

        [Test]
        public void CallTheUowCommitMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Tire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRimsRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Tire());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<Tire>();
            var pics = new List<TirePicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new TiresService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedUow.Verify(x => x.Commit(), Times.Once);
        }
    }
}
