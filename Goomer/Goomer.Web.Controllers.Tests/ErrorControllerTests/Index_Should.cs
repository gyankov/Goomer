using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Goomer.Web.Controllers.Tests.ErrorControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void Return_Error500View()
        {
            var controller = new ErrorController();

            controller.WithCallTo(x => x.Index()).ShouldRenderView("Error500");
        }
    }
}
