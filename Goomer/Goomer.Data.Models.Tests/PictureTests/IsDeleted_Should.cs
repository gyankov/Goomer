using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.PictureTests
{
    [TestFixture]
    public class IsDeleted_Should
    {

        [Test]
        public void TypeOfBool()
        {
            var bm = new Picture();

            var result = bm.IsDeleted.GetType();

            Assert.True(result == typeof(bool));
        }

       
    }
}
