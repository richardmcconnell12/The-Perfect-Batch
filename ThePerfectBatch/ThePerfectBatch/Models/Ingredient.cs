using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThePerfectBatch.Models
{
    public class Ingredient
    {
        [Display(Name = "Id")]
        public int IngredientId { get; set; }

        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}
