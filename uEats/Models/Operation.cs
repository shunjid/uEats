using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace uEats.Models
{
    public class Operation
    {
        public string TypeOfOperation { get; set; }

        public string RestaurantId { get; set; }

        public float MinimumProductPrice { get; set; }
        
        public float AmountToTrigger { get; set; }
    }
}