using backend.DomainObjects;
using backend.DomainServices;
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
                dbContext.Customers.Add(getValidCustomer());
                Assert.DoesNotThrowAsync(async () => await dbContext.SaveChangesAsync());
            }
        }

        private CustomerContext getTestDbContext()
        {
            var context = new CustomerContext();
            context.Database.EnsureCreated();

            return context;
        }

        private Customer getValidCustomer()
        {
            return new Customer()
            {
                FirstName = "dbTestFirstName",
                LastName = "dbTestLastName",
                CompanyName = "dbTestCompanyName"
            };
        }
    }
}