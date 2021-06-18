using backend.DomainServices;
using backendTests.DomainObjects;
using NUnit.Framework;

namespace backendTests.DomainServices
{
    [TestFixture]
    public class CustomerContextTests
    {
        [Test]
        public void Context_Customer_CanInsert()
        {
            using (var dbContext = getTestDbContext())
            {
                dbContext.Customers.Add(CustomerTests.GetValidCustomer());
                Assert.DoesNotThrowAsync(async () => await dbContext.SaveChangesAsync());
            }
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