using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var products = await _productService.GetListAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
           
            var products = await _productService.GetAsync(id);

            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _productService.UpdateAsync(product);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetAsync(id);
            await _productService.DeleteAsync(product);
            return CreatedAtAction(nameof(GetAll),product);

        }



    }
}
