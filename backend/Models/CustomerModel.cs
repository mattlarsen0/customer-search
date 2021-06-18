using System.ComponentModel.DataAnnotations;
using backend.DomainObjects;

namespace backend.Models
{
    public class CustomerModel
    {
        [Required]
        [MaxLength(Customer.MaxNameLength)]
        public string firstName { get; set; }
    
        [Required]
        [MaxLength(Customer.MaxNameLength)]
        public string lastName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(Customer.MaxNameLength)]
        public string companyName { get; set; }
    }
}