using GroceryLists.Data;
using GroceryLists.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryLists.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;

        public IngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            var entity = new Ingredient()
            {
                Name = model.Name,
                Quantity = model.Quantity
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ingredients
                    .Where(e => e.OwnerId == _userId)
                    .Select
                    (
                        e => new IngredientListItem
                        {
                            IngredientId = e.IngredientId,
                            Name = e.Name

                        }
                    );
                return query.ToArray();
            }
        }

        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ingredients
                    .Single(e => e.IngredientId == id && e.OwnerId == _userId);
                return
                new IngredientDetail
                {
                    IngredientId = entity.IngredientId,
                    Name = entity.Name,
                    Quantity = entity.Quantity

                };
            }
        }
        

        public bool UpdateIngredient(IngredientEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ingredients
                    .Single(e => e.IngredientId == model.IngredientId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Quantity = model.Quantity;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ingredients
                    .Single(e => e.IngredientId == ingredientId && e.OwnerId == _userId);
                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
