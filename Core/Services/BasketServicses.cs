using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Baskets;
using Shared.DTO_S.Basket;

namespace Services
{
    public class BasketServicses(IBasketRepository Repo , IMapper mapper) : IBasketServices
    {
        #region GetBasketAsync
        public async Task<BasketDto?> GetBasketAsync(string Key)
        {
            var Basket = await Repo.GetBasketAsync(Key);
            if (Basket is not null)
            {
                return mapper.Map<CustomerBasket, BasketDto>(Basket);
            }
            else
                throw new BasketNotFoundException(Key);
        }
        #endregion

        #region CreateOrUpdateBasketAsync
        public async Task<BasketDto?> CreateOrUpdateBasketAsync(BasketDto basket)
        {
            var CustomerBasket = mapper.Map<BasketDto, CustomerBasket>(basket);

            var CreatedOrUpdatedBasket = await Repo.CreateOrUpdateBasketAsync(CustomerBasket);

            if (CreatedOrUpdatedBasket is not null)
                return await GetBasketAsync(basket.Id);
            else
                throw new Exception("Can Not Update or Create Basket Now");
        }

        #endregion

        #region DeleteBasketAsync
        public async Task<bool> DeleteBasketAsync(string Key)
        {
            return await Repo.DeleteBasketAsync(Key);
        } 
        #endregion


    }
}
