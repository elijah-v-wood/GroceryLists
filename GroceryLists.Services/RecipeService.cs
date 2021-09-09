using GroceryLists.Data;
using GroceryLists.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity = new Recipe()
            {
                OwnerId = _userId,
                Name=model.Name,
                Ingredients=model.Ingredients,
                Instructions=model.Instructions,
                Access=model.Access,
                CreatedUtc=DateTimeOffset.Now
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
            }
        }
    }
}
