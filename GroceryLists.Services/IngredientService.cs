﻿using GroceryLists.Data;
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

        
    }
}