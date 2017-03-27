using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.RimWithTirePictureTests
{
    class RimWithTireId_Should
    {
        [Test]
        public void TypeOfInt()
        {
            var bm = new RimWithTirePicture();

            var result = bm.RimWithTireId.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void BeVirtualProperty()
        {
            var context = new RimWithTirePicture();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimWithTireId", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
    }
}
