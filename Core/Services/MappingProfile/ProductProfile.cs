using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models.Products;
using Shared.DTO_S;

namespace Services.MappingProfile
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        { 
            CreateMap<Products ,ProductDto>()
                .ForMember(Dist=>Dist.BrandName , options => options.MapFrom(Src=>Src.Brand.Name))
                .ForMember(Dist=>Dist.TypeName , options => options.MapFrom(Src=>Src.Type.Name));

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        
        }
    }
}
