using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Products
{
    public class ProductBrand : ModelBase<int>
    {
        public string Name { get; set; } = null!;

        public ICollection<Products> Products { get; set; } = new HashSet<Products>();
    }
}
