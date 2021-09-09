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
        public string Name { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        private bool Access { get; set; } = false;
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
