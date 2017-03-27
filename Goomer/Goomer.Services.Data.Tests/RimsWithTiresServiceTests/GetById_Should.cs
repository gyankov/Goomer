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
    public class GetById_Should
    {
        [Test]
        public void CallTheRimsRepoGetByIdMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new RimWithTire());
            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.GetById(1);

            //assert
            mockedRepo.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }
    }
}
