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

namespace Goomer.Services.Data.Tests.RimsServiceTests
{
    public class GetById_Should
    {
        [Test]
        public void CallTheRimsRepoGetByIdMethodOnce()
        {
            //Arrange
            var mockedRimsRepo = new Mock<IDbRepository<Rim>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRimsRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Rim());
            var service = new RimsService(mockedRimsRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.GetById(1);

            //assert
            mockedRimsRepo.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }
    }
}
