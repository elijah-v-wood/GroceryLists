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
    public class ShoppingListController : ApiController
    {
        private ShoppingListService CreateShoppingListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var shoppingListService = new ShoppingListService(userId);
            return shoppingListService;
        }


        public IHttpActionResult Post(ShoppingListCreate shoppingList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShoppingListService();

            if (!service.CreateShoppingList(shoppingList))
                return InternalServerError();

            return Ok("You created a new shopping list!");
        }



        // Gets all of the user's shopping lists (displays shopping list ID, title, description, and date created)
        public IHttpActionResult Get()
        {
            ShoppingListService shoppingListService = CreateShoppingListService();
            var shoppingLists = shoppingListService.GetShoppingLists();
            return Ok(shoppingLists);
        }


        // get shopping list by ID
        public IHttpActionResult Get(int id)
        {
            ShoppingListService shoppingListService = CreateShoppingListService();
            var shoppingList = shoppingListService.GetShoppingListById(id);
            return Ok(shoppingList);
        }

    }
}
