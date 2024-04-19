using LazyCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineRetailShopping.API.Caching;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using OnlineRetailShopping.Services.Interface;

namespace OnlineRetailShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        private ICacheProvider _cacheProvider;

        public ProductController(IProductService productService, ILogger<ProductController> logger, ICacheProvider cacheProvider ,IProductRepository productRepository)
        {
            _productService = productService;
            _logger = logger;
            _cacheProvider = cacheProvider;
            //_cache = cache;

        }
        [HttpGet]
        [Route("/Getproductbycache")]
        public async Task<ActionResult> GetCustomerCache()
        {
            if (_cacheProvider.TryGetValue(cachekeys.product, out List<Product> products))
                return Ok(products);

            products = await _productRepository.GetAll();

            var cacheEntryOption = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(30),
                Size = 1024
            };
            _cacheProvider.Set(cachekeys.product, products, cacheEntryOption);


            return Ok(products);
        }
        [HttpGet]
        [Route("Getproduct")]
        public async Task<IActionResult> Getproduct()
        {
            var Product = await _productService.GetProductsAll();
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);

        }
        [HttpGet("GetProductbyID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetProductbyID(Guid ID)
        {
            var Product = await _productService.GetProductById(ID);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [HttpGet("GetProductbyName")]
        public async Task<IActionResult> GetProductbyName(string Name)
        { 
            var products = await _productService.GetProductByName(Name);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Postproduct(Product pro)
        {
            var postpro = await _productService.CreateProduct(pro);
            return CreatedAtAction(nameof(Getproduct), new { ID = pro.productId }, pro);
        }
        [HttpPut("PutProductbyId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProductbyId(Guid productId, Product pro)
        {
            var putpro = await _productService.UpdateProduct(productId,pro);
            if (!(putpro))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var productdel = await _productService.DeleteProduct(productId);
            if (productdel == false)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
