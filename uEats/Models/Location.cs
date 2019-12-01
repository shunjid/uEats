using System.ComponentModel.DataAnnotations;

namespace uEats.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationCity { get; set; }
    }
}