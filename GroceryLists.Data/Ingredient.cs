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
        public int InredientId { get; set; }
        [Required]
        public string Name { get; set; }

        public int? Quantity { get; set; }
    }
}
