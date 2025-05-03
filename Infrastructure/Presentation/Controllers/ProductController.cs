using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTO_S;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController(IServicesManager servicesManager) :ControllerBase
    {
        [HttpGet]
        public async Task<PaginatedResult<ProductDto>> GetAllProducts([FromQuery] ProductQueryParams ProductQueryParams)
        {
            var products = await servicesManager.ProductServices.GetAllProductsAsync(ProductQueryParams);
            return Ok(products);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await servicesManager.ProductServices.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var Types = await servicesManager.ProductServices.GetAllTypesAsync();
            return Ok(Types);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductById(int id)
        {
            var product = await servicesManager.ProductServices.GetProductByIdAsync(id);
            return Ok(product);
        }
    }
}
