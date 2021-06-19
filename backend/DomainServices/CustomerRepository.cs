using System.Collections.Generic;
using backend.DomainObjects;
using System;
using System.Linq;

namespace backend.DomainServices
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> Search(string nameQuery, string companyNameQuery);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext databaseContext = new CustomerContext();

        public IEnumerable<Customer> Search(string nameQuery, string companyNameQuery)
        {
            IEnumerable<Customer> filteredResults = databaseContext.Customers;

            if (!string.IsNullOrWhiteSpace(nameQuery))
            {
                filteredResults = filteredResults.Where(c => 
                    c.FirstName.Contains(nameQuery, StringComparison.InvariantCultureIgnoreCase) || 
                    c.LastName.Contains(nameQuery, StringComparison.InvariantCultureIgnoreCase)
                );
            }

            if (!string.IsNullOrWhiteSpace(companyNameQuery))
            {
                filteredResults = filteredResults.Where(c => 
                    c.CompanyName.Contains(companyNameQuery, StringComparison.InvariantCultureIgnoreCase)
                );
            }

            return filteredResults;
        }

        public void Dispose()
        {
            databaseContext.Dispose();
        }
    }
}