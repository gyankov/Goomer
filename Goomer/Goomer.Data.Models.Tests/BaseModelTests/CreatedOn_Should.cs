using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
   public class CreatedOn_Should
    {
        [Test]
        public void TypeOfDateTime()
        {
            var bm = new BaseModel();
            bm.CreatedOn = new DateTime(1995, 1, 1);
            var result = bm.CreatedOn.GetType();

            Assert.True(result == typeof(DateTime));
        }
    }
}
