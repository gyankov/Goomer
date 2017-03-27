using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.TireTests
{
    public class Height_Should
    {
        [Test]
        public void TypeOfDoubel()
        {
            var rim = new Tire();

            var result = rim.Height.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void HaveRangeAttribute()
        {
            var rim = new Tire();

            var result = rim
                .GetType()
                .GetProperty("Height")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var rim = new Tire();

            var result = rim
                .GetType()
                .GetProperty("Height")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
