using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace uEats.Models
{
    public class FoodRestaurant
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }
        
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime AddedIn { get; set; }

        public float FoodRestaurantPrice { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}