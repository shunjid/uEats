using System.ComponentModel.DataAnnotations;

namespace uEats.Data
{
    public class AuthUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}