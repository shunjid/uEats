using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public Account Account { get; set; }
        
        public Location Location { get; set; }

        public List<FoodRestaurant> FoodRestaurants { get; set; }
        
        [NotMapped] public List<SelectListItem> Locations { get; }
    }
}