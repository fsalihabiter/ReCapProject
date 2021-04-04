using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(b => b.Id == id);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brandDal.GetAll(filter);
        }

        public bool Insert(Brand brand)
        {
            return _brandDal.Add(brand);
        }

        public bool Update(Brand brand)
        {
            return _brandDal.Update(brand);
        }

        public bool Delete(Brand brand)
        {
            return _brandDal.Delete(brand);
        }
    }
}
