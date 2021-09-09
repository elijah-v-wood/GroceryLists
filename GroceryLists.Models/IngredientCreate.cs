using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class IngredientCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Ingredient name must be at least 2 characters long")]
        public string Name { get; set; }

        // should there be a min value required for adding an ingredient?
        public int Quantity { get; set; }
    }
}
