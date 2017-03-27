using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Data.Models.BaseModels;
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
    public class AddNewTireAd_Should
    {
        [Test]
        public void CallTheUsersServiceGetByIdMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRimsRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Rim());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<Rim>();
            var pics = new List<RimPicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);
            
            //act
            service.AddNewTireAd("",mockedRim.Object,new List<string> { "gosho"});

            //assert
            mockedUsersService.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void CallTheRimsRepoAddIdMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRimsRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Rim());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<Rim>();
            var pics = new List<RimPicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedRimsRepo.Verify(x => x.Add(It.IsAny<Rim>()), Times.Once);
        }

        [Test]
        public void CallTheUowCommitMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRimsRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Rim());
            mockedUsersService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new User());
            var mockedRim = new Mock<Rim>();
            var pics = new List<RimPicture>();
            mockedRim.Setup(x => x.Pictures).Returns(pics);
            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.AddNewTireAd("", mockedRim.Object, new List<string> { "gosho" });

            //assert
            mockedUow.Verify(x => x.Commit(), Times.Once);
        }
    }
}
