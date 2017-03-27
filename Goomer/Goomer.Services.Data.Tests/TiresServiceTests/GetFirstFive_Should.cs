using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Goomer.Data.Models.SearchModels;
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
    class GetFirstFive_Should
    {
        [Test]
        public void CallTheRimsRepoAllMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<Tire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            var rims = new List<Tire> { new Tire() };
            mockedRepo.Setup(x => x.All()).Returns(rims.AsQueryable());
            var service = new TiresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.GetFirstFive(new TiresSearchModel());

            //assert
            mockedRepo.Verify(x => x.All(), Times.Once);
        }
    }
}
