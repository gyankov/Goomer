using Goomer.Data.Models.BaseModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.PictureTests
{
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(Picture);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfIAuditInfo()
        {
            var bm = new Picture();

            Assert.That(bm, Is.InstanceOf<IAuditInfo>());
        }

        [Test]
        public void CreateInstanceOfIDeletableEntity()
        {
            var bm = new Picture();

            Assert.That(bm, Is.InstanceOf<IDeletableEntity>());
        }
    }
}
