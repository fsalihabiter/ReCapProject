using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public Color Get(int id)
        {
            return _colorDal.Get(c => c.Id == id);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colorDal.GetAll(filter);
        }

        public bool Insert(Color color)
        {
            return _colorDal.Add(color);
        }

        public bool Update(Color color)
        {
            return _colorDal.Update(color);
        }

        public bool Delete(Color color)
        {
            return _colorDal.Delete(color);
        }
    }
}
