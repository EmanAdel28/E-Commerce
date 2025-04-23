using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Products;
using Shared.DTO_S;

namespace Services
{
    public class ProductServices(IUnitOfWork unitOfWork , Mapper mapper) : IProductServices
    {

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var _Repository = unitOfWork.GetRepository<Products, int>();
            var products = await _Repository.GetAllAsync();
            var MappedProduct = Mapper.Map<IEnumerable<Products>, IEnumerable<ProductDto>>(products);
            return MappedProduct;
        }
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductBrand, int>();
            var Brands = await _Repository.GetAllAsync();
            var MappedBrands = Mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
            return MappedBrands;
            
        }



        public  async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var _Repository = unitOfWork.GetRepository<ProductType, int>();
            var Types = await _Repository.GetAllAsync();
            var MappedTypes = Mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return MappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
           var product = await unitOfWork.GetRepository<Products,int>().GetByIdAsync(id);
            return Mapper.Map<Products,ProductDto>(product);
        }
    }
}
