using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class IngredientListItem
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
    }
}
