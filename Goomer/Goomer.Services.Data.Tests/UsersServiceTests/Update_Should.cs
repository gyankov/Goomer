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
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void CallGetByIdMethodOfUsersRepo()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var service = new UsersService(mockedRepo.Object, mockedUow.Object);
            var users = new List<User> { new User { UserName = "gosho", IsDeleted = false } };
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new User());

            service.Update("gosho", false, "", "", false);

            mockedRepo.Verify(x => x.GetById(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void CallUpdateMethodOfUsersRepo()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var service = new UsersService(mockedRepo.Object, mockedUow.Object);
            var users = new List<User> { new User { UserName = "gosho", IsDeleted = false } };
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new User());

            service.Update("gosho", false, "", "", false);

            mockedRepo.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void CallCommintOfUow()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var service = new UsersService(mockedRepo.Object, mockedUow.Object);
            var users = new List<User> { new User { UserName = "gosho", IsDeleted = false } };
            mockedRepo.Setup(x => x.GetById(It.IsAny<object>())).Returns(new User());

            service.Update("gosho", false, "", "", false);

            mockedUow.Verify(x => x.Commit(), Times.Once);
        }
    }
}
