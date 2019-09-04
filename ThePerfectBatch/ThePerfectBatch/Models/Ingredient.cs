using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThePerfectBatch.Models
{
    public class Ingredients
    {
        [Display(Name = "Id")]
        public int IngredientsId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}
