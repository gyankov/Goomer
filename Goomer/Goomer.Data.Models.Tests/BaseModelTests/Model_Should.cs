﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.BaseModelTests
{
    [TestFixture]
    public class Model_Should
    {
        [TestCase("jpeg")]
        [TestCase("gif")]
        public void TypeOfString(string test)
        {
            var bm = new BaseModel();
            bm.Model = test;
            var result = bm.Model.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void HaveRequiredAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Model")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMinlengthAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Model")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.MinLengthAttribute))
                .Any();

            Assert.True(result);
        }

        [Test]
        public void HaveMaxlengthAttribute()
        {
            var bm = new BaseModel();

            var result = bm
                .GetType()
                .GetProperty("Model")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
