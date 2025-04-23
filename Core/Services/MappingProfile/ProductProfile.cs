using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shared.DTO_S;

namespace Services.MappingProfile
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        { 
            CreateMap<Product ,ProductDto>()
                .ForMember(Dist=>Dist.BrandName , options => options.MapFrom(Src=>Src.BrandName));
        
        }
    }
}
