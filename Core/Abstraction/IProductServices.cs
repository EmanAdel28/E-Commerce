using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Shared.DTO_S;

namespace Abstraction
{
    public interface IProductServices
    {
        Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams productQueryParams);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

    }
}
