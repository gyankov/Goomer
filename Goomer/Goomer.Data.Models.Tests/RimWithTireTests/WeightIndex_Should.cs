using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.RimWithTireTests
{
    [TestFixture]
    public class WeightIndex_Should
    {
        [TestCase("jpeg")]
        [TestCase("gif")]
        public void TypeOfString(string test)
        {
            var bm = new RimWithTire();
            bm.WeightIndex = test;
            var result = bm.WeightIndex.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var bm = new RimWithTire();

            var result = bm
                .GetType()
                .GetProperty("WeightIndex")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveStringLengthAttributeAttribute()
        {
            var bm = new RimWithTire();

            var result = bm
                .GetType()
                .GetProperty("WeightIndex")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
