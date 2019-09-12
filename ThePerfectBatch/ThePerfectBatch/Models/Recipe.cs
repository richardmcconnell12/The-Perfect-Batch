using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThePerfectBatch.Models
{
    public class Recipe
    {
        [Key]
        [Display(Name = "Id")]
        public int? RecipeId { get; set; }

        [Display(Name = "Recipe Type")]
        public int RecipeTypeId { get; set; }

        public virtual RecipeType RecipeType { get; set; }

        [Display(Name = "Meal")]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        
        [Display(Name = "Created by")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public string Image { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
