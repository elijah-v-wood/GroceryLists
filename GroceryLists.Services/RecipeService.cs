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
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetMyRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Recipes
                    .Where(r => r.OwnerId == _userId)
                    .Select
                    (
                        r => new RecipeListItem
                        {
                            RecipeId = r.RecipeId,
                            Name = r.Name,
                            CreatedUtc = r.CreatedUtc,
                        }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Recipes
                    .Where(r => r.OwnerId == _userId || r.Access)
                    .Select
                    (
                        r => new RecipeListItem
                        {
                            RecipeId = r.RecipeId,
                            Name = r.Name,
                            CreatedUtc = r.CreatedUtc,
                        }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<RecipeListItem> GetAllOtherRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Recipes
                    .Where(r => r.Access)
                    .Select
                    (
                        r => new RecipeListItem
                        {
                            RecipeId = r.RecipeId,
                            Name = r.Name,
                            CreatedUtc = r.CreatedUtc,
                        }
                    );
                return query.ToArray();
            }
        }

    }
}
