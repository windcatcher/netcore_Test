using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public interface IProductImgRepository
    {
        /**
	 * 基本插入
	 * 
	 * @return
	 */
         int addImg(ProductImg img);

        /**
         * 根据主键查询
         */
        ProductImg getImgByKey(int id);

        /**
         * 根据主键批量查询
         */
         List<ProductImg> getImgsByKeys(List<int> idList);

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
         int updateImgByKey(ProductImg img);

        /**
         * 根据条件查询分页查询
         * 
         * @param imgQuery
         *            查询条件
         * @return
         */
         //Pagination getImgListWithPage(ImgQuery imgQuery);

        /**
         * 根据条件查询
         * 
         * @param imgQuery
         *            查询条件
         * @return
         */
         List<ProductImg> getImgList(Expression<Func<ProductImg, bool>> imgQuery);
    }
}
