using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
    public class Description_Should
    {
        [TestCase("jpeg")]
        [TestCase("gif")]
        public void TypeOfString(string test)
        {
            var bm = new BaseModel();
            bm.Description = test;
            var result = bm.Description.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Description")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
