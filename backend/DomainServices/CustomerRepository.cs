using System.Collections.Generic;
using backend.DomainObjects;
using System;

namespace backend.DomainServices
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> Search();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext databaseContext = new CustomerContext();

        public IEnumerable<Customer> Search()
        {
            return databaseContext.Customers;
        }

        public void Dispose()
        {
            databaseContext.Dispose();
        }
    }
}