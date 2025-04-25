using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Products;
using Shared;

namespace Services.Specification
{
    public class ProductWithBrandAndYypeSpecifications:BaseSpecifications<Products,int>
    {
        public ProductWithBrandAndYypeSpecifications(ProductQueryParams ProductQueryParams) :base
            (p=>(!ProductQueryParams.BrandId.HasValue || p.BrandId== ProductQueryParams.BrandId)
            &&(!ProductQueryParams.TypeId.HasValue || p.TypeId== ProductQueryParams.TypeId))
        {
            AddInclude(P=>P.Brand);
            AddInclude(P=>P.Type);

            switch(ProductQueryParams.SortOrder)
            {
                case ProductSortingOption.NameAsc:
                    AddOrderBy(P => P.Name);
                    break;
                case ProductSortingOption.NameDesc:
                    AddOrderByDesc(P => P.Name);
                    break;
                case ProductSortingOption.PriceAsc:
                    AddOrderBy(P => P.Price);
                    break;
                case ProductSortingOption.PriceDesc:
                    AddOrderByDesc(P => P.Price);
                    break;
                default:
                    break;



            }

        }

        public ProductWithBrandAndYypeSpecifications(int id):base(p=>p.Id == id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.Type);
        }
    }
}
