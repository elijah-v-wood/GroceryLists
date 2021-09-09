using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class ShoppingListListItem
    {
        public int ShoppingListId { get; set; }
        public string Title { get; set; }

        [Display(Name="Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
