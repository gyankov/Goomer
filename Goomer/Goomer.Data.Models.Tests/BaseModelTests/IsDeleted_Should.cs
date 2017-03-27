using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [Test]
        public void TypeOfBool()
        {
            var bm = new BaseModel();

            var result = bm.IsDeleted.GetType();

            Assert.True(result == typeof(bool));
        }

        [Test]
        public void HaveIndexAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("IsDeleted")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.Schema.IndexAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
