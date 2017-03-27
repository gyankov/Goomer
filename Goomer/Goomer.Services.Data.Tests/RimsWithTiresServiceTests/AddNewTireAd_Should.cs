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
    public class AddNewTireAd_Should
    {
        [Test]
        public void CallTheUsersServiceGetByIdMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new RimWithTire());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<RimWithTire>();
            var pics = new List<RimWithTirePicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedUsersService.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void CallTheRimsRepoAddIdMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new RimWithTire());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<RimWithTire>();
            var pics = new List<RimWithTirePicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedRepo.Verify(x => x.Add(It.IsAny<RimWithTire>()), Times.Once);
        }

        [Test]
        public void CallTheUowCommitMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new RimWithTire());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<RimWithTire>();
            var pics = new List<RimWithTirePicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedUow.Verify(x => x.Commit(), Times.Once);
        }
    }
}
