using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Products
{
    public class Products : ModelBase<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public Decimal Price { get; set; }
        public ProductBrand Brand { get; set; }
        public int BrandId { get; set; }
        public ProductType Type { get; set; }

        public int TypeId { get; set; }

    }
}
