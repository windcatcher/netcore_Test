using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public interface IColorRepository
    {
        /**
 * 基本插入
 * 
 * @return
 */
        int addColor(Color color);

        /**
         * 根据主键查询
         */
        Color getColorByKey(int id);

        /**
         * 根据主键批量查询
         */
        IEnumerable<Color> getColorsByKeys(List<int> idList);

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
        int updateColorByKey(Color color);

        /**
         * 根据条件查询分页查询
         * 
         * @param colorQuery
         *            查询条件
         * @return
         */
        //  Pagination getColorListWithPage(ColorQuery colorQuery);

        /**
         * 根据条件查询
         * 
         * @param colorQuery
         *            查询条件
         * @return
         */
        IEnumerable<Color> getColorList(Expression<Func<Color, bool>> colorQuery);
    }
}
