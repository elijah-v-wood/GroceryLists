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
        public IEnumerable<RecipeListItem> GetAllPublic()
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

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity = ctx.Recipes
                    .Single(r => (r.RecipeId == id && r.OwnerId == _userId)||(r.RecipeId==id && r.Access));

                return
                    new RecipeDetail
                    {
                        RecipeId = entity.RecipeId,
                        Name = entity.Name,
                        Ingredients = entity.Ingredients,
                        Instructions = entity.Instructions,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public IEnumerable<RecipeListItem> GetRecipesByIngredient(Ingredient ingredient)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Recipes
                    .Where
                    (r => 
                    (r.Ingredients.
                    Contains(ingredient) && r.OwnerId == _userId) || (r.Ingredients.
                    Contains(ingredient) && r.Access))
                    .Select
                    (
                        r => new RecipeListItem
                        {
                            RecipeId = r.RecipeId,
                            Name = r.Name,
                            CreatedUtc = r.CreatedUtc,
                        }
                    );
                return entity.ToArray();
            }

        }

        public bool EditRecipe(RecipeEdit model)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var entity = ctx.Recipes
                    .Single(r => r.RecipeId == model.RecipeId && r.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Ingredients = model.Ingredients;
                entity.Instructions = model.Instructions;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity = ctx.Recipes
                    .Single(r => r.RecipeId == recipeId && r.OwnerId == _userId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
