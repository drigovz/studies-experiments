using System;
using System.Threading.Tasks;
using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiConventionType(typeof(DefaultApiConventions))]
   [Produces("application/json")]
   [ApiController]
   public class BasketController : ControllerBase
   {
      private readonly IBasketRepository _repository;

      public BasketController(IBasketRepository repository)
      {
         _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      }

      [HttpGet("{userName}", Name = "GetBasket")]
      public async Task<ActionResult<ShoppingCart>> GetBasketAsync(string userName)
      {
         var basket = await _repository.GetBasket(userName);

         // verificamos no primeiro acesso se o registro é null, se ele for, criamos ele no Redis
         return Ok(basket ?? new ShoppingCart(userName));
      }

      [HttpPost]
      public async Task<ActionResult<ShoppingCart>> UpdateBasketAsync([FromBody] ShoppingCart basket)
      {
         return Ok(await _repository.UpdateBasket(basket));
      }

      [HttpDelete("{userName}", Name = "DeleteBasket")]
      public async Task<IActionResult> DeleteBasketAsync(string userName)
      {
         await _repository.DeleteBasket(userName);
         return Ok();
      }
   }
}
