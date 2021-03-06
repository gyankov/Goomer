﻿using Goomer.Data.Common.Contracts;
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
    public class GetByUsername_Should
    {
        [Test]
        public void CallAllMethodOfUsersRepol()
        {
            var mockedRepo = new Mock<IDbRepository<User>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var service = new UsersService(mockedRepo.Object, mockedUow.Object);
            var users = new List<User>();
            mockedRepo.Setup(x => x.All()).Returns(users.AsQueryable());

            var all = service.GetByUserName("gosho");

            mockedRepo.Verify(x => x.All(), Times.Once);
        }
    }
}
