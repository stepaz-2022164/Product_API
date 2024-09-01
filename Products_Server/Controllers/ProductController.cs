using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_Server.Models;

namespace Products_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductController(ProductsContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("createProducts")]
        public async Task<ActionResult>CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("getProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("getProduct")]
        public async Task<IActionResult>GetProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, Product product) 
        {
            var productExist = await _context.Products.FindAsync(id);
            if (productExist == null)
            {
                return NotFound();
            }
            productExist!.Name = product.Name;
            productExist!.Description = product.Description;
            productExist!.Price = product.Price;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDeleted = await _context.Products.FindAsync(id);
            if (productDeleted == null)
            {
                return NotFound();
            }
            _context.Products.Remove(productDeleted);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
