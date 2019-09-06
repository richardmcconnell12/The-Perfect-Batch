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
        public int RecipeId { get; set; }

        [Display(Name = "Recipe Type")]
        public int RecipeTypeId { get; set; }

        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        
        public virtual ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
