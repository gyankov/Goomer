using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.RimPictureTests
{
    [TestFixture]
    public class RimId_Should
    {
        [Test]
        public void TypeOfInt()
        {
            var bm = new RimPicture();

            var result = bm.RimId.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void BeVirtualProperty()
        {
            var context = new RimPicture();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimId", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
    }
}
