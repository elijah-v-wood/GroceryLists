using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Models
{
    public class ShoppingListCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Exceeded List Title character limit")]
        public string Title { get; set; }

        [MaxLength(280, ErrorMessage = "Exceeded List Description character limit")]
        public string Description { get; set; }
    }
}
