using Goomer.Data.Common.Contracts;
using Goomer.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Data.Tests.UsersServiceTests
{
    class GetById_Should
    {

        [Test]
        public void InstantiatesCorrectly_WhenAllDependenciesAreNotNull()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var service = new UsersService(mockedRepo.Object, mockedUow.Object);
            var users = new List<User>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new User());

            var user = service.GetById(1);

            mockedRepo.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }
    }
}
