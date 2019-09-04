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

        [Required]
        public ApplicationUser UserCreated { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }
    }
}
