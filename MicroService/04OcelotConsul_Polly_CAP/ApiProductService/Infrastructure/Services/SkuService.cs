using ApiProductService.Infrastructure.Repositories;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Services
{
    public class SkuService : ISkuSubscribService, ICapSubscribe
    {
        private ISkuRepository skuRep;

        public SkuService(ISkuRepository skuRep)
        {
            this.skuRep = skuRep;
        }

        [CapSubscribe("Orderservices.Order.Create")]
        public void ReceiveCreateOrderMessage(dynamic orderInfo)
        {

            int skuId = (int)orderInfo.SkuId.Value;
            int oderItemcount = (int)orderInfo.Amount.Value;

            //throw new NullReferenceException();
            Sku sku = skuRep.getSkuByKey(skuId);
            sku.StockInventory -= oderItemcount;
            skuRep.updateSkuByKey(sku);
        }



    }
}
