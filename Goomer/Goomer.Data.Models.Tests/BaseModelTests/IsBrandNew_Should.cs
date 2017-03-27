using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
    public class IsBrandNew_Should
    {

        [Test]
        public void TypeOfBool()
        {
            var bm = new BaseModel();
            var result = bm.IsBrandNew.GetType();

            Assert.True(result == typeof(bool));
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("IsBrandNew")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
