using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        
        public string FoodName { get; set; }

        public string FoodCategory { get; set; }
    }
}