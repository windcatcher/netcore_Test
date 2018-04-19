using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private ProductContext productContext;

        public ColorRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        public int addColor(Color color)
        {
            var color1 = productContext.Add(color).Entity;
            productContext.SaveChanges();
            return color1.Id;
        }

        public int deleteByKey(int id)
        {
            var sku = getColorByKey(id);
            if (sku == null) return -1;
            productContext.Color.Remove(sku);
            return id;
        }

        public int deleteByKeys(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public Color getColorByKey(int id)
        {
            return productContext.Color.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Color> getColorList(Expression<Func<Color, bool>> colorQuery)
        {
            if (colorQuery == null)
                return productContext.Color.ToList();
            return productContext.Color.Where(colorQuery).AsEnumerable();
        }

        public IEnumerable<Color> getColorsByKeys(List<int> idList)
        {
            throw new NotImplementedException();
        }

        public int updateColorByKey(Color color)
        {
            var color1 = this.productContext.Color.Update(color).Entity;
            this.productContext.SaveChangesAsync();
            return color1.Id;
        }
    }
}
