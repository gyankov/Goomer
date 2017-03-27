using Goomer.Data.Models.BaseModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.UserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(User);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }


        [Test]
        public void CreateInstanceOfIAuditInfo()
        {
            var rim = new User();

            Assert.That(rim, Is.InstanceOf<IAuditInfo>());
        }

        [Test]
        public void CreateInstanceOfIDeletableEntity()
        {
            var rim = new User();

            Assert.That(rim, Is.InstanceOf<IDeletableEntity>());
        }

        [Test]
        public void InitializeTiresCorrectly()
        {
            var rim = new User();

            var pictures = rim.Tires;

            Assert.That(pictures, Is.Not.Null.And.InstanceOf<HashSet<Tire>>());
        }
        [Test]
        public void InitializeRimsCorrectly()
        {
            var rim = new User();

            var pictures = rim.Rims;

            Assert.That(pictures, Is.Not.Null.And.InstanceOf<HashSet<Rim>>());
        }

        [Test]
        public void InitializeRimsWithTiresCorrectly()
        {
            var rim = new User();

            var pictures = rim.RimsWithTires;

            Assert.That(pictures, Is.Not.Null.And.InstanceOf<HashSet<RimWithTire>>());
        }
    }
}
