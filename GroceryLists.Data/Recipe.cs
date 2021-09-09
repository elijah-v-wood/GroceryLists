using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Data
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        private bool Access { get; set; } = false;

        public void PublicAccess()
        {
            Access = true;
        }


    }
}
