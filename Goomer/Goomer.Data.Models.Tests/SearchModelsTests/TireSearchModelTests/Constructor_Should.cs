using Goomer.Data.Models.SearchModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.SearchModelsTests.TireSearchModelTests
{
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(TiresSearchModel);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Brand_ShouldBe_TypeOfString(string test)
        {
            var bm = new TiresSearchModel();
            bm.Brand = test;
            var result = bm.Brand.GetType();

            Assert.True(result == typeof(string));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Model_ShouldBe_TypeOfString(string test)
        {
            var bm = new TiresSearchModel();
            bm.Model = test;
            var result = bm.Model.GetType();

            Assert.True(result == typeof(string));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Siting_ShouldBe_TypeOfString(string test)
        {
            var bm = new TiresSearchModel();
            bm.Siting = test;
            var result = bm.Siting.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void QuantityFrom_ShouldBe_TypeOfInt()
        {
            var rim = new TiresSearchModel();
            rim.QuantityFrom = 1;
            var result = rim.QuantityFrom.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void PriceFrom_ShouldBe_TypeOfDecimal()
        {
            var rim = new TiresSearchModel();
            rim.PriceFrom = 1;
            var result = rim.PriceFrom.GetType();

            Assert.True(result == typeof(decimal));
        }

        [Test]
        public void PriceTo_ShouldBe_TypeOfDecimal()
        {
            var rim = new TiresSearchModel();
            rim.PriceTo = 1;
            var result = rim.PriceTo.GetType();

            Assert.True(result == typeof(decimal));
        }

        [Test]
        public void Size_ShouldBe_TypeOfDouble()
        {
            var rim = new TiresSearchModel();
            rim.Size = 1;
            var result = rim.Size.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void Width_ShouldBe_TypeOfDouble()
        {
            var rim = new TiresSearchModel();
            rim.Width = 1;
            var result = rim.Width.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void OnlyBrandNew_ShouldBe_TypeOfBool()
        {
            var rim = new TiresSearchModel();

            var result = rim.OnlyBrandNew.GetType();

            Assert.True(result == typeof(bool));
        }

        [Test]
        public void SpeedIndex_ShouldBe_TypeOfInt()
        {
            var rim = new TiresSearchModel();
            rim.SpeedIndexFrom = 1;
            var result = rim.SpeedIndexFrom.GetType();

            Assert.True(result == typeof(int));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void WeightIndex_ShouldBe_TypeOfString(string test)
        {
            var bm = new TiresSearchModel();
            bm.WeightIndex = test;
            var result = bm.WeightIndex.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void GrappleMm_ShouldBe_TypeOfDouble()
        {
            var rim = new TiresSearchModel();
            rim.GrappleFrom = 1;
            var result = rim.GrappleFrom.GetType();

            Assert.True(result == typeof(double));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Season_ShouldBe_TypeOfString(string test)
        {
            var bm = new TiresSearchModel();
            bm.Season = test;
            var result = bm.Season.GetType();

            Assert.True(result == typeof(string));
        }
    }
}
