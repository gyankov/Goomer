using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.RimWithTireTests
{
    [TestFixture]
    public class SpeedIndex_Should
    {
        [Test]
        public void TypeOfInt()
        {
            var rim = new RimWithTire();

            var result = rim.SpeedIndex.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void HaveRangeAttribute()
        {
            var rim = new RimWithTire();

            var result = rim
                .GetType()
                .GetProperty("SpeedIndex")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var rim = new RimWithTire();

            var result = rim
                .GetType()
                .GetProperty("SpeedIndex")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
