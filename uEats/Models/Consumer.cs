using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Consumer
    {
        [Key]
        public string ConsumerId { get; set; }

        public string ConsumerName { get; set; }

        public int ConsumerAge { get; set; }
        
        public string ChoiceOfTaste { get; set; }

        public string CustomerStatus { get; set; }
        
        public Account Account { get; set; }
        
        public Location Location { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}