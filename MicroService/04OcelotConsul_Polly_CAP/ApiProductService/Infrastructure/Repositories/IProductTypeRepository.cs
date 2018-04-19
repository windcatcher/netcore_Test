using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    interface IProductTypeRepository
    {
         int addType(ProductType type);

        /**
         * 根据主键查询
         */
         ProductType getTypeByKey(int id);

        /**
         * 根据主键批量查询
         */
         List<ProductType> getTypesByKeys(List<int> idList);

        /**
         * 根据主键删除
         * 
         * @return
         */
         int deleteByKey(int id);

        /**
         * 根据主键批量删除
         * 
         * @return
         */
         int deleteByKeys(List<int> idList);

        /**
         * 根据主键更新
         * 
         * @return
         */
         int updateTypeByKey(ProductType type);

        /**
         * 根据条件查询分页查询
         * 
         * @param typeQuery
         *            查询条件
         * @return
         */
        // Pagination getTypeListWithPage(TypeQuery typeQuery);

        /**
         * 根据条件查询
         * 
         * @param typeQuery
         *            查询条件
         * @return
         */
         List<Type> getTypeList(Expression<Func<Type, bool>> typeQuery);
    }
}
