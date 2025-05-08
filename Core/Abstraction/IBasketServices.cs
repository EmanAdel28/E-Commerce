using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO_S.Basket;

namespace Abstraction
{
    public interface IBasketServices
    {
        Task<BasketDto?> GetBasketAsync(string Key);
        Task<BasketDto?> CreateOrUpdateBasketAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string Key);
    }
}
