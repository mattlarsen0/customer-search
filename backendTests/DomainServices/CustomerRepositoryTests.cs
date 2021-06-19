using backend.DomainObjects;
using backend.DomainServices;
using backendTests.DomainObjects;
using NUnit.Framework;
using System.Linq;

namespace backendTests.DomainServices
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        const string firstNameSearchQuery = "#1abc";
        const string firstNameSearchUpper = "#1ABC";
        const string lastNameSearchQuery = "#2abc";
        const string lastNameSearchUpper = "#2ABC";
        const string companyNameSearchQuery = "#3abc";
        const string companyNameSearchUpper = "#3ABC";

        [SetUp]
        public void Setup()
        {
            using (var context = new CustomerContext())
            {
                // re-create db if it exists
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        [Test]
        public void Repo_Customer_CanDispose()
        {
            var customerRepo = new CustomerRepository();
            Assert.DoesNotThrow(customerRepo.Dispose);
        }
        
        [TestCase(firstNameSearchQuery, companyNameSearchQuery)]
        [TestCase(lastNameSearchQuery, companyNameSearchQuery)]
        [TestCase(firstNameSearchQuery, null)]
        [TestCase(lastNameSearchQuery, null)]
        [TestCase(firstNameSearchUpper, null)]
        [TestCase(lastNameSearchUpper, null)]
        [TestCase(null, companyNameSearchUpper)]
        [TestCase(null, companyNameSearchQuery)]
        [TestCase("", null)]
        [TestCase(null, "")]
        [TestCase(null, "  ")]
        [TestCase("   ", null)]
        public void Repo_Search_ByNameDoesFind(string customerNameQuery, string companyNameQuery)
        {
            var testCustomer = insertBasicSearchTestData();

            using (var customerRepo = new CustomerRepository())
            {
                var foundIds = customerRepo.Search(customerNameQuery, companyNameQuery).Select(c => c.Id);

                Assert.That(foundIds, Has.Member(testCustomer.Id));
            }
        }
        
        [TestCase("jkl;", "asdf")]
        [TestCase("test", "test")]
        [TestCase("fakeName", "444444444")]
        [TestCase(firstNameSearchQuery + "invalid", null)]
        [TestCase(lastNameSearchQuery + "invalid", null)]
        [TestCase(null, companyNameSearchQuery + "invalid")]
        public void Repo_Search_ByNameDoesNotFind(string customerNameQuery, string companyNameQuery)
        {
            var testCustomer = insertBasicSearchTestData();

            using (var customerRepo = new CustomerRepository())
            {
                var foundIds = customerRepo.Search(customerNameQuery, companyNameQuery).Select(c => c.Id);

                Assert.That(foundIds, Has.No.Member(testCustomer.Id));
            }
        }

        private void AddCustomer(Customer customer)
        {
            using (var context = new CustomerContext())
            {
                context.Add(customer);

                context.SaveChanges();
            }
        }

        private Customer getSearchTestCustomer()
        {
            return new Customer()
            {
                FirstName = "#1abc-first",
                LastName = "#2abc-last",
                CompanyName = "#3abc-company",
            };
        }

        private Customer insertBasicSearchTestData()
        {
            var testCustomer = getSearchTestCustomer();

            AddCustomer(CustomerTests.GetValidCustomer());
            AddCustomer(CustomerTests.GetValidCustomer());
            AddCustomer(testCustomer);
            AddCustomer(CustomerTests.GetValidCustomer());
            AddCustomer(CustomerTests.GetValidCustomer());

            return testCustomer;
        }
    }
}