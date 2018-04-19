using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    interface IBrandRepository
    {
        // Pagination GetBrandListWithPage(Brand brand);

        //查询集合
        List<Brand> GetBrandList(Expression<Func<Brand, bool>> brandQuery);

        //添加品牌
        void AddBrand(Brand brand);

        //删除
        void DeleteBrandByKey(int id);
        //删除 批量
        void DeleteBrandByKeys(int[] ids);//List<int>  ids
                                          //修改
        void UpdateBrandByKey(Brand brand);

        //
        Brand GetBrandByKey(int id);
    }
}
