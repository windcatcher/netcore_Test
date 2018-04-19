using ApiProductService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRep;
        private ISkuRepository skuRep;
        private IProductImgRepository imgRep;

        public ProductService(IProductRepository productRep, ISkuRepository skuRep, IProductImgRepository imgRep)
        {
            this.productRep = productRep;
            this.skuRep = skuRep;
            this.imgRep = imgRep;
        }

    }
}
