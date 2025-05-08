using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models.Baskets;
using StackExchange.Redis;
namespace Persistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connectionMultiplexer): IBasketRepository
    {
     
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

        #region GetBasketAsync
        public async Task<CustomerBasket?> GetBasketAsync(string Key)
        {
            var Basket = await _database.StringGetAsync(Key);

            if (Basket.IsNullOrEmpty)
                return null;
            else
                return JsonSerializer.Deserialize<CustomerBasket>(Basket!);

        }
        #endregion

        #region CreateOrUpdateBasketAsync
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket customerBasket)
        {
            var jsonBasket = JsonSerializer.Serialize(customerBasket);
            var IsCreatedOrUpdated = await _database.StringSetAsync(customerBasket.Id, jsonBasket, TimeSpan.FromDays(30));

            if (IsCreatedOrUpdated)
                return await GetBasketAsync(customerBasket.Id);
            else
                return null;

        }

        #endregion

        #region DeleteBasketAsync
        public async Task<bool> DeleteBasketAsync(string Key)
        {
            return await _database.KeyDeleteAsync(Key);
        } 
        #endregion


    }
}
