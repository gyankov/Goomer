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

namespace Goomer.Services.Data.Tests.RimsWithTiresServiceTests
{
    [TestFixture]
    public class GetFirstFive_Should
    {
        [Test]
        public void CallTheRimsRepoAllMethodOnce()
        {
            //Arrange
            var mockedRepo = new Mock<IDbRepository<RimWithTire>>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedUow = new Mock<IUnitOfWork>();
            var rims = new List<RimWithTire> { new RimWithTire() };
            mockedRepo.Setup(x => x.All()).Returns(rims.AsQueryable());
            var service = new RimsWithTyresService(mockedRepo.Object, mockedUsersService.Object, mockedUow.Object);

            //act
            service.GetFirstFive(new RimsWithTiresSearchModel());

            //assert
            mockedRepo.Verify(x => x.All(), Times.Once);
        }
    }
}
