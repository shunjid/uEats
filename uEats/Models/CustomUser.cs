using Microsoft.AspNetCore.Identity;

namespace uEats.Models
{
    public class CustomUser : IdentityUser
    {
        public string Role { get; set; }
    }
}