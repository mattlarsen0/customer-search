using System.ComponentModel.DataAnnotations;

namespace backend.DomainObjects
{
    public class Customer
    {
        public const int MaxNameLength = 50;

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }
    
        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(MaxNameLength)]
        public string Company { get; set; }
    }
}