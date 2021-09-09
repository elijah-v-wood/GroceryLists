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
        var userId = Guid.Parse(User.Identity.GetUserId())
    }
}
