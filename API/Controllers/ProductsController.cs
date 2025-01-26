using System.Reflection;
using Core.Entities;
using Core.Interfaces;
using Infrastrcture.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductsRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await repo.GetProductsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product != null)
                return Ok(product);
            
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.AddProduct(product);
            if (await repo.SaveChangesAsync())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }

            return BadRequest("Problem creating product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            var isExist = repo.ProductExist(id);

            if (!isExist) return BadRequest("Cannot update this product");

            repo.UpdateProduct(product);
            
            if(await repo.SaveChangesAsync())
                return NoContent();
            
            return BadRequest("Problem updating product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            repo.DeleteProduct(product);

            if (await repo.SaveChangesAsync())
                return NoContent();

            return BadRequest("Problem deleting product");        
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var brands = await repo.GetBrandsAsync();

            if (brands == null)
                return NotFound();

            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<string>> GetTypes()
        {
            var types = await repo.GetTypesAsync();

            if (types == null)
                return NotFound();

            return Ok(types);
        }
    }
}
