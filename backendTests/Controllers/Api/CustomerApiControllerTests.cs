using backend.Controllers;
using NUnit.Framework;
using System.Net;

namespace backend.Tests 
{
    [TestFixture]
    public class CustomerApiControllerTests
    {
        [Test]
        public void CustomerApi_Search_ReturnsOk()
        {
            var controller = new CustomerApiController();
            var apiResult = controller.Search();

            Assert.That(apiResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        }
    }
}