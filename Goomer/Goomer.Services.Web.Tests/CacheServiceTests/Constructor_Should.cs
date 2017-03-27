using Goomer.Services.Web.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Services.Web.Tests.CacheServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(HttpCacheService);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfIChacheService()
        {
            var rim = new HttpCacheService();

            Assert.That(rim, Is.InstanceOf<ICacheService>());
        }
    }
}
