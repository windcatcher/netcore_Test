using ApiProductService.Infrastructure.Aop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public interface ISkuRepository
    {
        /// <summary>
        /// 基本插入
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        int addSku(Sku sku);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Sku getSkuByKey(int id);

        /// <summary>
        /// 根据主键批量查询
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        IEnumerable<Sku> getSkusByKeys(List<int> idList);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int deleteByKey(int id);

        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        int deleteByKeys(List<int> idList);

        /// <summary>
        /// 根据主键更新
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        int updateSkuByKey(Sku sku);

        /**
         * 根据条件查询分页查询
         * 
         * @param skuQuery
         *            查询条件
         * @return
         */
        // Pagination getSkuListWithPage(SkuQuery skuQuery);

        /**
         * 根据条件查询
         * 
         * @param skuQuery
         *            查询条件
         * @return
         */
        IEnumerable<Sku> getSkuList(Expression<Func<Sku, bool>> skuQuery);

        /**
         * 库存大于>0
         */
        [MemcacheDoBefore]
        IEnumerable<Sku> getStock(int productId);
    }
}
