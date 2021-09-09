using GroceryLists.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }

        [MaxLength(500, ErrorMessage = "Too many characters in the Name")]
        public string Name { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
