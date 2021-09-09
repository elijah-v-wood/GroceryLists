using GroceryLists.Data;
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

    public class RecipeController : ApiController
    {
        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var recipeService = new RecipeService(userId);

            return recipeService;
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var recipeService = CreateRecipeService();
            var recipes = recipeService.GetAllRecipes();

            return Ok(recipes);
        }
        [HttpGet]
        public IHttpActionResult GetMy()
        {
            var recipeService = CreateRecipeService();
            var recipes = recipeService.GetMyRecipes();

            return Ok(recipes);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var recipeService = CreateRecipeService();
            var recipe = recipeService.GetRecipeById(id);

            return Ok(recipe);
        }
        [HttpGet]
        public IHttpActionResult GetPublic()
        {
            var recipeService = CreateRecipeService();
            var recipes = recipeService.GetAllPublic();

            return Ok(recipes);
        }
        [HttpGet]
        public IHttpActionResult GetByIngredient([FromBody]Ingredient ingredient)
        {
            var recipeService = CreateRecipeService();
            var recipes = recipeService.GetRecipesByIngredient(ingredient);

            return Ok(recipes);
        }
        [HttpPost]
        public IHttpActionResult PostRecipe(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipeService = CreateRecipeService();
            if (!recipeService.CreateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PutRecipe(RecipeEdit edit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recipeService = CreateRecipeService();
            if (!recipeService.EditRecipe(edit))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteRecipe([FromBody]int id)
        {
            var recipeService = CreateRecipeService();
            if (!recipeService.DeleteRecipe(id))
                return InternalServerError();

            return Ok();
        }
    }
}
