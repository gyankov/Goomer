using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Goomer.Web.Controllers.Tests.ErrorControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(ErrorController);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfController()
        {
            var controller = new ErrorController();

            Assert.That(controller, Is.InstanceOf<Controller>());
        }
    }
}
