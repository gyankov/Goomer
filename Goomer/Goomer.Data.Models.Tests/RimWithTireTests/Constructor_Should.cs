using Goomer.Data.Models.BaseModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.RimWithTireTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(RimWithTire);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfIRim()
        {
            var rim = new RimWithTire();

            Assert.That(rim, Is.InstanceOf<IRim>());
        }

        [Test]
        public void CreateInstanceOfITire()
        {
            var rim = new RimWithTire();

            Assert.That(rim, Is.InstanceOf<ITire>());
        }

        [Test]
        public void CreateInstanceOfBaseModel()
        {
            var rim = new RimWithTire();

            Assert.That(rim, Is.InstanceOf<BaseModel>());
        }

        [Test]
        public void InitializePicturesCorrectly()
        {
            var rim = new RimWithTire();

            var pictures = rim.Pictures;

            Assert.That(pictures, Is.Not.Null.And.InstanceOf<HashSet<RimWithTirePicture>>());
        }
    }
}
