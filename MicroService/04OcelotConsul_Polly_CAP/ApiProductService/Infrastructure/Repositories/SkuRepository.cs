using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public class SkuRepository : ISkuRepository
    {
        private ProductContext productContext;

        public SkuRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        public int addSku(Sku sku)
        {
            var sku1 = productContext.Add(sku).Entity;
            productContext.SaveChanges();
            return sku1.Id;
        }

        public int deleteByKey(int id)
        {
            var sku = getSkuByKey(id);
            if (sku == null) return -1;
            productContext.Sku.Remove(sku);
            return id;
        }

        public int deleteByKeys(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public Sku getSkuByKey(int id)
        {
            return productContext.Sku.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Sku> getSkuList(Expression<Func<Sku, bool>> skuQuery)
        {
            if (skuQuery == null)
                return productContext.Sku.ToList();
            return productContext.Sku.Where(skuQuery).AsEnumerable();
        }

        public IEnumerable<Sku> getSkusByKeys(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sku> getStock(int productId)
        {
            return productContext.Sku.Where(p => p.ProductId == productId).AsEnumerable();
        }

        public int updateSkuByKey(Sku sku)
        {
            var sku1 = this.productContext.Sku.Update(sku).Entity;
            this.productContext.SaveChangesAsync();
            return sku1.Id;
        }
    }
}
