using backend.ModelServices;
using backendTests.DomainObjects;
using NUnit.Framework;

namespace backendTests.ModelServices
{
    [TestFixture]
    public class CustomerAdapterTests
    {
        [Test]
        public void ApiAdapter_ConvertToModel_CanConvert()
        {
            var customer = CustomerTests.GetValidCustomer();
            var customerAdapter = new CustomerAdapter();
            var customerModel  =customerAdapter.ConvertToModel(customer);

            Assert.That(customerModel.firstName, Is.EqualTo(customer.FirstName));
            Assert.That(customerModel.lastName, Is.EqualTo(customer.LastName));
            Assert.That(customerModel.companyName, Is.EqualTo(customer.CompanyName));
        }
    }
}