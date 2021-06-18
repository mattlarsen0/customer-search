using backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace backend.Tests 
{
    [TestFixture]
    public class CustomerViewControllerTests
    {
        [Test]
        public void CustomerView_View_ReturnsView()
        {
            var controller = new CustomerViewController();
            var viewResult = controller.Index();

            Assert.That(viewResult, Is.TypeOf(typeof(ViewResult)));
        }
    }
}