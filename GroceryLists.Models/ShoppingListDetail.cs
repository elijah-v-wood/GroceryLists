using GroceryLists.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class ShoppingListDetail
    {
        public int ShoppingListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // need to add display for shopping list ingredients list in ShoppingListService
        //public List<Ingredient> Ingredients { get; set; }
        //public string[] Ingredients { get; set; }


        [Display(Name="Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
