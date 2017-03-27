using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
    public class DeletedOn_Should
    {
        [Test]
        public void TypeOfNullableDateTime()
        {
            var bm = new BaseModel();
            bm.DeletedOn = new DateTime(1995, 1, 1);
            var result = bm.DeletedOn.GetType();

            Assert.True(result == typeof(DateTime));
        }
    }
}
