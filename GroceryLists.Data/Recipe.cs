using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Data
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [MaxLength(500, ErrorMessage = "Too many characters in the Name")]
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        private bool Access { get; set; } = false;
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public void PublicAccess()
        {
            Access = true;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
    }
}
