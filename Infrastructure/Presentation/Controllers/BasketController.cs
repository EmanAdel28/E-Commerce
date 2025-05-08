using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO_S.Basket;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServicesManager servicesManager ):ControllerBase
    {
      
        #region GetBasket
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string Key)
        {
            var Basket = servicesManager.BasketServices.GetBasketAsync(Key);
            return Ok(Basket);
        }
        #endregion

        #region CreateOrUpdateBasket
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {
            var Basket = await servicesManager.BasketServices.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }
        #endregion

        #region DeleteBasket
        [HttpDelete("{Key}")]
        public async Task<ActionResult<bool>> DeleteBasket(string Key)
        {
            var Result = await servicesManager.BasketServices.DeleteBasketAsync(Key);
            return Ok(Result);
        }

        #endregion
    }
}
