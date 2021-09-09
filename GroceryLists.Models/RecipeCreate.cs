using GroceryLists.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class RecipeCreate
    {
        [Required]
        [MaxLength(500, ErrorMessage ="Too many characters in the Name")]
        public string Name { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public bool Access { get; set; } = false;
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
