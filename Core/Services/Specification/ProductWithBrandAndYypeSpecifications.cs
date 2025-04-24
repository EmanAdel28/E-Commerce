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
        public ProductWithBrandAndYypeSpecifications():base(null)
        {
            AddInclude(P=>P.Brand);
            AddInclude(P=>P.Type);

        }
    }
}
