using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        public int? Quantity { get; set; }
    }
}
