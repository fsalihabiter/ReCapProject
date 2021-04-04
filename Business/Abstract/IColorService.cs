using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll(Expression<Func<Color, bool>> filter = null);
        Color Get(int id);
        bool Insert(Color color);
        bool Update(Color color);
        bool Delete(Color color);
    }
}
