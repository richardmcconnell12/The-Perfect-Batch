using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThePerfectBatch.Models;

namespace ThePerfectBatch.Models
{
    public class RecipeType
    {
        [Display(Name = "Id")]
        public int RecipeTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Meal")]
        public ICollection<Recipe> Recipes { get; set; }
    }
}