﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
    public class Size_Should
    {
        [Test]
        public void TypeOfDouble()
        {
            var bm = new BaseModel();
            var result = bm.Size.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Size")
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
                .GetProperty("Size")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                .Any();

            Assert.True(result);
        }

    }
}
