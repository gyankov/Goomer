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
    public class Rim_Should
    {
        [Test]
        public void BeVirtualProperty()
        {
            var context = new RimPicture();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Rim", bindingFlags);

            Assert.That(commentsProperty.GetGetMethod().IsVirtual, Is.True);
        }
    }
}
