using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.PictureTests
{
    public class Id_Should
    {
        [Test]
        public void TypeOfInt()
        {
            var bm = new Picture();

            var result = bm.Id.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void HaveRangeAttribute()
        {
            var bm = new Picture();

            var result = bm
                .GetType()
                .GetProperty("Id")
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(System.ComponentModel.DataAnnotations.KeyAttribute))
                .Any();

            Assert.True(result);
        }
    }
}
