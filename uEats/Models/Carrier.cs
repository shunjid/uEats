using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Carrier
    {
        [Key]
        public string CarrierId { get; set; }
        public string CarrierName { get; set; }

        public int CarrierAge { get; set; }

        public string CarrierStatus { get; set; }

        public float CarrierAverageRating { get; set; }
        
        public Account Account { get; set; }

        public Location Location { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}