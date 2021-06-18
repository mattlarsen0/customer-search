using System.Collections.Generic;

namespace backend.Models
{
    public class CustomerListModel
    {
        public IEnumerable<CustomerModel> customers { get; set; }
    }
}