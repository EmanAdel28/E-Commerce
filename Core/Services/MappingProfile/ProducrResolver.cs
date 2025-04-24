using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using AutoMapper;

using Domain.Models.Products;
using Microsoft.Extensions.Configuration;
using Shared.DTO_S;

namespace Services.MappingProfile
{
    public class ProducrResolver(IConfiguration configuration) : IValueResolver<Products, ProductDto, string>
    {
        public string Resolve(Products source, ProductDto destination, string destMember, ResolutionContext context)
        {
           if(string.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;

            else
            {
                var Url = $"{configuration.GetSection("Urls")["BaseUrl"]}";

                return Url;
            }
        }
    }
}
