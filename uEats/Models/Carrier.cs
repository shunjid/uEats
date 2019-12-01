using System.Collections.Generic;

namespace uEats.Models
{
    public class Carrier
    {
        public string CarrierName { get; set; }

        public int CarrierAge { get; set; }

        public string CarrierStatus { get; set; }

        public float CarrierAverageRating { get; set; }
        
        public Account Account { get; set; }

        public Location Location { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}