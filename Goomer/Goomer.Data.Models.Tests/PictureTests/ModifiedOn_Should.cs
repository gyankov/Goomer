using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.PictureTests
{
    [TestFixture]
    class ModifiedOn_Should
    {
        [Test]
        public void TypeOfNullableDateTime()
        {
            var bm = new Picture();
            bm.ModifiedOn = new DateTime(1995, 1, 1);
            var result = bm.ModifiedOn.GetType();

            Assert.True(result == typeof(DateTime));
        }
    }
}
