using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext productContext;

        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public async Task<int> addProduct(Product product)
        {
            //商品编号
            var date = DateTime.Now.ToString("yyyyMMddHHmmssSSS");
            product.No = date;
            //添加时间
            product.CreateTime = DateTime.Now;
            //影响到行数   返回商品ID
            //商品保存  
            var newProduct = productContext.Product.Add(product).Entity;
            //1:商品   图片   sku
            //2:图片
            //1)设置图片商品ID
            product.Img.ProductId = newProduct.Id;
            //2)
            product.Img.IsDef = 1;
            productContext.ProductImg.Add(product.Img);
            //3:保存Sku    9,13,...
            //  S M  ...
            //实例化一个Sku对象
            Sku sku = new Sku();
            //商品ID

            sku.ProductId = newProduct.Id;
            //运费
            sku.DeliveFee = 10.00;
            //售价
            sku.SkuPrice = 0.00;
            //市场价
            sku.MarketPrice = 0.00;
            //库存
            sku.StockInventory = 0;
            //购买限制
            sku.SkuUpperLimit = 0;
            //添加时间
            sku.CreateTime = DateTime.Now;
            //是否最新
            sku.LastStatus = 1;
            //商品
            sku.SkuType = 1;
            //销量
            sku.Sales = 0;
            foreach (String color in product.Color.Split(","))
            {
                //颜色ID
                sku.ColorId = int.Parse(color);

                foreach (String size in product.Size.Split(","))
                {
                    //尺码
                    sku.Size = size;
                    //保存SKu
                    product.Skus.Add(sku);
                }

            }
            await productContext.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task<int> deleteByKey(int id)
        {
            var product = await getProductByKey(id);
            if (product == null) return -1;
            productContext.Product.Remove(product);
            await productContext.SaveChangesAsync();
            return id;
        }

        public async Task<int> deleteByKeys(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> getProductByKey(int id)
        {
            return productContext.Product.SingleOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> getProductList(Expression<Func<Product, bool>> productQuery)
        {
            if (productQuery == null)
                return productContext.Product.ToList();
            return productContext.Product.Where(productQuery).AsEnumerable();
        }

        public async Task<IEnumerable<Product>> getProductsByKeys(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public async Task<int> updateProductByKey(Product product)
        {
            var product1 = productContext.Product.Update(product).Entity;
            await productContext.SaveChangesAsync();
            return product1.Id;
        }
    }
}
