using GroceryLists.Data;
using GroceryLists.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Services
{
    public class ShoppingListService
    {
        private readonly Guid _userId;

        public ShoppingListService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShoppingList(ShoppingListCreate model)
        {
            var entity = new ShoppingList()
            {
                OwnerId = _userId,
                Title = model.Title,
                Description = model.Description,
                CreatedUtc = DateTimeOffset.Now,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        // method to get all of a user's shopping lists
        public IEnumerable<ShoppingListListItem> GetShoppingLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ShoppingLists.Where(s => s.OwnerId == _userId)
                    .Select(s => new ShoppingListListItem
                    {
                        ShoppingListId = s.ShoppingListId,
                        Title = s.Title,
                        Description = s.Description,
                        CreatedUtc = s.CreatedUtc
                    });
                return query.ToArray();
            }
        }

        // method to get a particular shopping list by its ID
        public ShoppingListDetail GetShoppingListById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ShoppingLists.Single(s => s.ShoppingListId == id && s.OwnerId == _userId);
                return
                    new ShoppingListDetail
                    {
                        ShoppingListId = entity.ShoppingListId,
                        Title = entity.Title,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        // how to display ingredients in ShoppingList Ingredients?
                    };
            }
        }
    }
}
