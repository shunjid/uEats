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
    }
}