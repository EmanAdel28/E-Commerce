using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Products;

namespace Services.Specification
{
    public class ProductWithBrandAndYypeSpecifications:BaseSpecifications<Products,int>
    {
        public ProductWithBrandAndYypeSpecifications(int? brandId, int? TypeId) :base
            (p=>(!brandId.HasValue || p.BrandId==brandId)
            &&(!TypeId.HasValue || p.TypeId==TypeId))
        {
            AddInclude(P=>P.Brand);
            AddInclude(P=>P.Type);

        }

        public ProductWithBrandAndYypeSpecifications(int id):base(p=>p.Id == id)
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.Type);
        }
    }
}
