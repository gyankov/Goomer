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
    public class CheckIfDeleted_Should
    {
        [Test]
        public void CallAllMethodOfUsersRepo()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var service = new UsersService(mockedRepo.Object, mockedUow.Object);
            var users = new List<User> { new User {UserName="gosho", IsDeleted = false } };
            mockedRepo.Setup(x => x.All()).Returns(users.AsQueryable());

            var user = service.ChekIfDeleted("gosho");

            mockedRepo.Verify(x => x.All(), Times.Once);
        }
    }
}
