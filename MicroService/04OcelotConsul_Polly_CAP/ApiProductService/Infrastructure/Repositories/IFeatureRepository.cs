using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    interface IFeatureRepository
    {
        /**
	 * 基本插入
	 * 
	 * @return
	 */
        int addFeature(Feature feature);

        /**
         * 根据主键查询
         */
        Feature getFeatureByKey(int id);

        /**
         * 根据主键批量查询
         */
        List<Feature> getFeaturesByKeys(List<int> idList);

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
        int updateFeatureByKey(Feature feature);

        /**
         * 根据条件查询分页查询
         * 
         * @param featureQuery
         *            查询条件
         * @return
         */
        // Pagination getFeatureListWithPage(FeatureQuery featureQuery);

        /**
         * 根据条件查询
         * 
         * @param featureQuery
         *            查询条件
         * @return
         */
        List<Feature> getFeatureList(Expression<Func<Feature, bool>> featureQuery);
    }
}
