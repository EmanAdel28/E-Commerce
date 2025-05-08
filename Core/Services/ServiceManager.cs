using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using AutoMapper;
using Domain.Contracts;

namespace Services
{
    public class ServiceManager(IUnitOfWork unitOfWork , IMapper mapper , IBasketRepository basketRepository) : IServicesManager
    {
        #region ProductServices
        private readonly Lazy<IProductServices> _LazyProductServices = new Lazy<IProductServices>(() => new ProductServices(unitOfWork, mapper));
        public IProductServices ProductServices => _LazyProductServices.Value;
        #endregion

        #region BasketServices
        private readonly Lazy<IBasketServices> _LazyBasketServices = new Lazy<IBasketServices>(() => new BasketServicses(basketRepository, mapper));
        public IBasketServices BasketServices => _LazyBasketServices.Value; 
        #endregion
    }
}
