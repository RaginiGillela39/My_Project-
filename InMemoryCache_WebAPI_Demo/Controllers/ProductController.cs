using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache_WebAPI_Demo.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //Implementing Response caching..
        //[ResponseCache(Duration =60, Location = ResponseCacheLocation.Client)]

        private readonly IMemoryCache _memoryCache;

        public ProductController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet()]
        public IActionResult GetProduct()
        {
            string cacheKey = "ProductKey";

            if (_memoryCache.TryGetValue(cacheKey, out List<string> products))
            {

                //var product=new Product { Id = id, Name = "Smartphone", Price = 500 };
                // return Ok(product);
                // If not in cache, fetch from the database (mocked here)
                products = new List<string> { "Laptop", "Mobile", "Headphones" };

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)) // Expires in 10 minutes
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5)); // Refresh if accessed

                // Store in cache
                _memoryCache.Set(cacheKey, products, cacheOptions);

            }
            return Ok(products);
        }
    }
}

