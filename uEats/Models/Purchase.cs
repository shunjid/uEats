using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        public Consumer Consumer { get; set; }

        public FoodRestaurant FoodRestaurant { get; set; }

        public Carrier Carrier { get; set; }

        public bool IsDelivered { get; set; }

        public int PurchaseRating { get; set; }

        public float PurchaseAmount { get; set; }
    }
}