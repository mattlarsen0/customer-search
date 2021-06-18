using backend.Controllers;
using backend.DomainObjects;
using backend.DomainServices;
using backend.Models;
using backend.ModelServices;
using backendTests.DomainObjects;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace backend.Tests 
{
    [TestFixture]
    public class CustomerApiControllerTests
    {
        private Mock<ICustomerRepository> mockRepo = new Mock<ICustomerRepository>();
        private Mock<ICustomerAdapter> mockAdapter = new Mock<ICustomerAdapter>();
        private readonly Customer[] testCustomers = new Customer[] {
            CustomerTests.GetValidCustomer(),
            CustomerTests.GetValidCustomer(),
            CustomerTests.GetValidCustomer()
        };
        
        [SetUp]
        public void Setup()
        {
            mockRepo.Reset();
            mockAdapter.Reset();
        }
        
        [Test]
        public void CustomerApi_Search_CallsProvidedSearchWithParams()
        {
            var searchQuery = "testSearchQuery";
            var companyNameQuery = "testCompanyName";

            mockRepo.Setup(r => r.Search(searchQuery, companyNameQuery)).Returns(testCustomers);
            var controller = getTestController(mockRepo.Object, mockAdapter.Object);

            controller.Search(search: searchQuery, filter_by_company_name: companyNameQuery);
            mockRepo.Verify(r => r.Search(searchQuery, companyNameQuery), Times.Once);
        }

        [Test]
        public void CustomerApi_Search_CallsProvidedSearch()
        {
            mockRepo.Setup(r => r.Search(It.IsAny<string>(), It.IsAny<string>())).Returns(testCustomers);
            var controller = getTestController(mockRepo.Object, mockAdapter.Object);

            controller.Search();
            mockRepo.Verify(r => r.Search(null, null), Times.Once);
        }
        
        [Test]
        public void CustomerApi_Search_CallsProvidedAdapter()
        {
            mockRepo.Setup(r => r.Search(It.IsAny<string>(), It.IsAny<string>())).Returns(testCustomers);
            var controller = getTestController(mockRepo.Object, mockAdapter.Object);

            controller.Search(string.Empty, string.Empty);
            mockAdapter.Verify(a => a.ConvertToModel(It.IsAny<Customer>()), Times.Exactly(testCustomers.Length));
        }
        
        [Test]
        public void CustomerApi_Search_ReturnsJson()
        {
            mockRepo.Setup(r => r.Search(It.IsAny<string>(), It.IsAny<string>())).Returns(testCustomers);
            var controller = getTestController(mockRepo.Object, mockAdapter.Object);

            var response = controller.Search(string.Empty, string.Empty);
            
            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<CustomerListModel>(response.Content));
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }
        
        [Test]
        public void CustomerApi_DisposeDatabase_DisposesDbRepo()
        {
            mockRepo.Setup(r => r.Dispose());
            var controller = getTestController(mockRepo.Object, mockAdapter.Object);

            controller.DisposeDatabase();
            
            mockRepo.Verify(r => r.Dispose(), Times.Once);
        }

        private CustomerApiController getTestController(ICustomerRepository databaseRepo, ICustomerAdapter customerAdapter)
        {
            var controller = new CustomerApiController(
                databaseRepo: databaseRepo, 
                customerAdapter: customerAdapter
            );

            return controller;
        }
    }
}