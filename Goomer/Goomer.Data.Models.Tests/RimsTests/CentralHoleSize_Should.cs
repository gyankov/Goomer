using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.RimsTests
{
    [TestFixture]
   public class CentralHoleSize_Should
    {
        [Test]
        public void TypeOfDouble()
        {
            var rim = new Rim();

            var result = rim.CentralHoleSize.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void HaveRangeAttribute()
        {
            var rim = new Rim();

            var result = rim
                .GetType()
                .GetProperty("CentralHoleSize")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var rim = new Rim();

            var result = rim
                .GetType()
                .GetProperty("CentralHoleSize")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
