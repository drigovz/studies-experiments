using Catalog.API.Entities;
using Catalog.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiConventionType(typeof(DefaultApiConventions))]
   [Produces("application/json")]
   [ApiController]
   public class CatalogController : ControllerBase
   {
      private readonly IProductRepository _repository;

      public CatalogController(IProductRepository repository)
      {
         _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
      {
         var products = await _repository.GetProductsAsync();
         return Ok(products);
      }

      [HttpGet("{id:length(24)}", Name = "GetProductAsync")]
      public async Task<ActionResult<Product>> GetProductAsync(string id)
      {
         var product = await _repository.GetProductAsync(id);
         if (product is null)
            return NotFound();

         return Ok(product);
      }

      [Route("[action]/{category}", Name = "GetProductByCategoryAsync")]
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategoryAsync(string category)
      {
         if (category is null)
            return BadRequest("Invalid category");

         var products = await _repository.GetProductByCategoryAsync(category);
         return Ok(products);
      }

      [HttpPost]
      public async Task<ActionResult<Product>> CreateProductAsync([FromBody] Product product)
      {
         if (product is null)
            return BadRequest("Invalid Product");

         await _repository.CreateProductAsync(product);
         return CreatedAtRoute("GetProductAsync", new { id = product.Id }, product);
      }

      [HttpPut]
      public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
      {
         if (product is null)
            return BadRequest("Invalid product");

         return Ok(await _repository.UpdateProductAsync(product));
      }

      [HttpDelete]
      public async Task<IActionResult> DeleteProductAsync(string id)
      {
         return Ok(await _repository.DeleteProductAsync(id));
      }
   }
}
