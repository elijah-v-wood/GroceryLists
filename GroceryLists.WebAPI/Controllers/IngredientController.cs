using GroceryLists.Models;
using GroceryLists.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryLists.WebAPI.Controllers
{
    [Authorize]
    public class IngredientController : ApiController
    {
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var IngredientService = new IngredientService(userId);
            return IngredientService;
        }

        public IHttpActionResult Get()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetIngredients();
            return Ok(ingredients);
        }

        public IHttpActionResult Post(IngredientCreate ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateIngredientService();
            if (!service.CreateIngredient(ingredient))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredient = ingredientService.GetIngredientById(id);
            return Ok(ingredient);
        }

        public IHttpActionResult Put(IngredientEdit ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateIngredientService();
            if (!service.UpdateIngredient(ingredient))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateIngredientService();
            if (!service.DeleteIngredient(id))
                return InternalServerError();
            return Ok();
        }

    }
}
