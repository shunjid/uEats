using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Restaurant
    {
        [Key]
        public string RestaurantId { get; set; }
        
        [MinLength(5)]
        public string RestaurantName { get; set; }

        public string RestaurantStatus { get; set; }

        public float RestaurantAverageRating { get; set; }
    }
}