using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationCity { get; set; }

        public List<Consumer> Consumers { get; set; }

        public List<Restaurant> Restaurants { get; set; }

        public List<Carrier> Carriers { get; set; }
    }
}