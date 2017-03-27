using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.TirePictureTests
{
    [TestFixture]
    public class TireId_Should
    {
        [Test]
        public void TypeOfInt()
        {
            var bm = new TirePicture();

            var result = bm.TireId.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void BeVirtualProperty()
        {
            var context = new TirePicture();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("TireId", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
    }
}
