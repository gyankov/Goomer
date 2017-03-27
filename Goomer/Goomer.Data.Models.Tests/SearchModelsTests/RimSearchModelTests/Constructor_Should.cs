using Goomer.Data.Models.SearchModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.Tests.SearchModelsTests.RimSearchModelTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void BeParametless()
        {
            var type = typeof(RimsSearchModel);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var ctor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(ctor, Is.Not.Null);
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Brand_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsSearchModel();
            bm.Brand = test;
            var result = bm.Brand.GetType();

            Assert.True(result == typeof(string));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Model_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsSearchModel();
            bm.Model = test;
            var result = bm.Model.GetType();

            Assert.True(result == typeof(string));
        }

        [TestCase("jpeg")]
        [TestCase("gif")]
        public void Siting_ShouldBe_TypeOfString(string test)
        {
            var bm = new RimsSearchModel();
            bm.Siting = test;
            var result = bm.Siting.GetType();

            Assert.True(result == typeof(string));
        }

        [Test]
        public void QuantityFrom_ShouldBe_TypeOfInt()
        {
            var rim = new RimsSearchModel();
            rim.QuantityFrom = 1;
            var result = rim.QuantityFrom.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void PriceFrom_ShouldBe_TypeOfDecimal()
        {
            var rim = new RimsSearchModel();
            rim.PriceFrom = 1;
            var result = rim.PriceFrom.GetType();

            Assert.True(result == typeof(decimal));
        }

        [Test]
        public void PriceTo_ShouldBe_TypeOfDecimal()
        {
            var rim = new RimsSearchModel();
            rim.PriceTo = 1;
            var result = rim.PriceTo.GetType();

            Assert.True(result == typeof(decimal));
        }

        [Test]
        public void Size_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsSearchModel();
            rim.Size = 1;
            var result = rim.Size.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void Width_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsSearchModel();
            rim.Width = 1;
            var result = rim.Width.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void SpaceBetweenBolts_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsSearchModel();
            rim.SpaceBetweenBolts = 1;
            var result = rim.SpaceBetweenBolts.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void NumberBolts_ShouldBe_TypeOfInt()
        {
            var rim = new RimsSearchModel();
            rim.NumberOfBolts = 1;
            var result = rim.NumberOfBolts.GetType();

            Assert.True(result == typeof(int));
        }

        [Test]
        public void CentralHoleSize_ShouldBe_TypeOfDouble()
        {
            var rim = new RimsSearchModel();
            rim.CentralHoleSize = 1;
            var result = rim.CentralHoleSize.GetType();

            Assert.True(result == typeof(double));
        }

        [Test]
        public void OnlyBrandNew_ShouldBe_TypeOfBool()
        {
            var rim = new RimsSearchModel();

            var result = rim.OnlyBrandNew.GetType();

            Assert.True(result == typeof(bool));
        }
    }
}
