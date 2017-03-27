using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    public class Quantity_Should
    {
        [Test]
        public void TypeOfInt()
        {
            var bm = new BaseModel();
            var result = bm.Quantity.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Quantity")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveRangeAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Quantity")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                .Any();

            Assert.True(result);
        }
        
    }
}
