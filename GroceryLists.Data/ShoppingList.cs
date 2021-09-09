using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Data
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingListId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Exceeded List Title character limit")]
        public string Title { get; set; }
        [Required]
        [MaxLength(280, ErrorMessage = "Exceeded List Description character limit")]
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
