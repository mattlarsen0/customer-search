using backend.DomainObjects;
using backend.Models;

namespace backend.ModelServices
{
    public interface ICustomerAdapter
    {
        CustomerModel ConvertToModel(Customer customer);
    }

    public class CustomerAdapter : ICustomerAdapter
    {
        public CustomerModel ConvertToModel(Customer customer)
        {
            return new CustomerModel()
            {
                id = customer.Id,
                firstName = customer.FirstName,
                lastName = customer.LastName,
                companyName = customer.CompanyName
            };      
        }
    }
}