using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Products;
using Services.Specification;
using Shared;
using Shared.DTO_S;

namespace Services
{
    public class ProductServices(IUnitOfWork unitOfWork , IMapper mapper) : IProductServices
    {

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams productQueryParams)
        {
            var _Repository = unitOfWork.GetRepository<Products, int>();
            var spec = new ProductWithBrandAndYypeSpecifications(productQueryParams);
            var products = await _Repository.GetAllAsync(spec);
            var MappedProduct = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDto>>(products);
            var CountedProducts = products.Count();
            return new PaginatedResult<ProductDto>(productQueryParams.PageIndex, CountedProducts, 0, MappedProduct);
           
        }
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductBrand, int>();
            var Brands = await _Repository.GetAllAsync();
            var MappedBrands = mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
            return MappedBrands;
            
        }



        public  async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductType, int>();
            var Types = await _Repository.GetAllAsync();
            var MappedTypes = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return MappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithBrandAndYypeSpecifications(id);
            var product = await unitOfWork.GetRepository<Products,int>().GetByIdAsync(spec);
            return mapper.Map<Products,ProductDto>(product);
        }

       
    }
}
