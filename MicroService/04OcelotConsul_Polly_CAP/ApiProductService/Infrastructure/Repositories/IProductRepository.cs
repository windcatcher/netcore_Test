using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        /**
	 * 基本插入
	 * 
	 * @return
	 */
        Task<int> addProduct(Product product);

        /**
         * 根据主键查询
         */
        Task<Product>  getProductByKey(int id);

        /**
         * 根据主键批量查询
         */
        Task<IEnumerable<Product>> getProductsByKeys(List<int> idList);

        /**
         * 根据主键删除
         * 
         * @return
         */
        Task<int> deleteByKey(int id);

        /**
         * 根据主键批量删除
         * 
         * @return
         */
        Task<int> deleteByKeys(List<int> idList);

        /**
         * 根据主键更新
         * 
         * @return
         */
        Task<int> updateProductByKey(Product product);

        /**
         * 根据条件查询分页查询
         * 
         * @param productQuery
         *            查询条件
         * @return
         */
        //  Pagination getProductListWithPage(ProductQuery productQuery);

        /**
         * 根据条件查询
         * 
         * @param productQuery
         *            查询条件
         * @return
         */
        Task<IEnumerable<Product>> getProductList(Expression<Func<Product, bool>> productQuery);
    }
}
