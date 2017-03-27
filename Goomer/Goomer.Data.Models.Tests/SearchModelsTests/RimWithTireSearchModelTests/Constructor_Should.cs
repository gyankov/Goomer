using Goomer.Data.Models.SearchModels;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Goomer.Data.Models.Tests.SearchModelsTests.RimWithTireSearchModelTests
{
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(RimsWithTiresSearchModel);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Brand_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsWithTiresSearchModel();
            bm.Brand = test;
            var result = bm.Brand.GetType();

            Assert.True(result == typeof(string));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Model_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsWithTiresSearchModel();
            bm.Model = test;
            var result = bm.Model.GetType();

            Assert.True(result == typeof(string));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Siting_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsWithTiresSearchModel();
            bm.Siting = test;
            var result = bm.Siting.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void QuantityFrom_ShouldBe_TypeOfInt()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.QuantityFrom = 1;
            var result = rim.QuantityFrom.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void PriceFrom_ShouldBe_TypeOfDecimal()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.PriceFrom = 1;
            var result = rim.PriceFrom.GetType();

            Assert.True(result == typeof(decimal));
        }

        [Test]
        public void PriceTo_ShouldBe_TypeOfDecimal()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.PriceTo = 1;
            var result = rim.PriceTo.GetType();

            Assert.True(result == typeof(decimal));
        }

        [Test]
        public void Size_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.Size = 1;
            var result = rim.Size.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void Width_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.Width = 1;
            var result = rim.Width.GetType();

            Assert.True(result == typeof(double));
        }
        [Test]
        public void SpaceBetweenBolts_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.SpaceBetweenBolts = 1;
            var result = rim.SpaceBetweenBolts.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void NumberBolts_ShouldBe_TypeOfInt()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.NumberOfBolts = 1;
            var result = rim.NumberOfBolts.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void CentralHoleSize_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.CentralHoleSize = 1;
            var result = rim.CentralHoleSize.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void OnlyBrandNew_ShouldBe_TypeOfBool()
        {
            var rim = new RimsWithTiresSearchModel();

            var result = rim.OnlyBrandNew.GetType();

            Assert.True(result == typeof(bool));
        }

        [Test]
        public void SpeedIndex_ShouldBe_TypeOfInt()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.SpeedIndexFrom = 1;
            var result = rim.SpeedIndexFrom.GetType();

            Assert.True(result == typeof(int));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void WeightIndex_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsWithTiresSearchModel();
            bm.WeightIndex = test;
            var result = bm.WeightIndex.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void GrappleMm_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsWithTiresSearchModel();
            rim.GrappleFrom = 1;
            var result = rim.GrappleFrom.GetType();

            Assert.True(result == typeof(double));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Season_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsWithTiresSearchModel();
            bm.Season = test;
            var result = bm.Season.GetType();

            Assert.True(result == typeof(string));
        }
    }
}
