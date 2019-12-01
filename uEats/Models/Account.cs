using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }

        public string AccountUserName { get; set; }

        public string AccountRole { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string AccountEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string AccountPhoneNumber { get; set; }
    }
}