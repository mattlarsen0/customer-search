using backend.DomainServices;
using backendTests.DomainObjects;
using NUnit.Framework;

namespace backendTests.DomainServices
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void Repo_Customer_CanDispose()
        {
            var customerRepo = new CustomerRepository();

            Assert.DoesNotThrow(customerRepo.Dispose);
        }

        private CustomerContext getTestDbContext()
        {
            var context = new CustomerContext();

            // re-create db if it exists
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}