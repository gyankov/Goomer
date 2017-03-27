using Goomer.Data;
using Goomer.Data.Contracts;
using Goomer.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Tests.ApplicationDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var type = typeof(ApplicationDbContext);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceOfDbContext()
        {
            var context = new ApplicationDbContext();

            Assert.That(context, Is.InstanceOf<DbContext>());
        }

        [Test]
        public void CreateInstanceOfIApplicationDbContext()
        {
            var context = new ApplicationDbContext();

            Assert.That(context, Is.InstanceOf<IApplicationDbContext>());
        }

        [Test]
        public void CreateInstanceWithRimsProperty()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Rims", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceWithTiresProperty()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Tires", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceWithRimsWithTiresProperty()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimsWithTires", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }


        [Test]
        public void CreateInstanceWithRimPicturesProperty()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimPictures", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceWithTirePicturesProperty()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("TirePictures", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceWithRimWithTirePicturesProperty()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimWithTirePictures", bindingFlags);

            Assert.That(commentsProperty, Is.Not.Null);
        }

        [Test]
        public void CreateInstanceWithRimsPropertyOfTypeIDbSet()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Rims", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Rim>)));
        }

        [Test]
        public void CreateInstanceWithTiresPropertyOfTypeIDbSet()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("Tires", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Tire>)));
        }

        [Test]
        public void CreateInstanceWithRimsWithTiresPropertyOfTypeIDbSet()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimsWithTires", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<RimWithTire>)));
        }

        [Test]
        public void CreateInstanceWithRimPicturesPropertyOfTypeIDbSet()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimPictures", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<RimPicture>)));
        }

        [Test]
        public void CreateInstanceTirePicturesPropertyOfTypeIDbSet()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("TirePictures", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<TirePicture>)));
        }

        [Test]
        public void CreateInstanceRimWithTirePicturesPropertyOfTypeIDbSet()
        {
            var context = new ApplicationDbContext();
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var commentsProperty = context.GetType().GetProperty("RimWithTirePictures", bindingFlags);

            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<RimWithTirePicture>)));
        }
    }
}
