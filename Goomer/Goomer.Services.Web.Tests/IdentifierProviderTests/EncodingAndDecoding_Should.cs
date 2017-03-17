using Goomer.Services.Web.Contracts;
using NUnit.Framework;

namespace Goomer.Services.Web.Tests.IdentifierProviderTests
{
    [TestFixture]
   public class EncodingAndDecoding_Should
    {
        [Test]
        public void EncodingAndDecodingDoesntChangeTheId()
        {
            const int Id = 1337;
            IIdentifierProvider provider = new IdentifierProvider();
            var encoded = provider.EncodeId(Id);
            var actual = provider.DecodeId(encoded);
            Assert.AreEqual(Id, actual);
        }
    }
}   
