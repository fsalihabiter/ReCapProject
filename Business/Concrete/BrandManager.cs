using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            if (_brandDal.Get(filter) == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotGeted);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(filter), Messages.BrandGeted);
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            if (filter == null)
            {
                if (_brandDal.GetAll().Count <= 0)
                {
                    return new ErrorDataResult<List<Brand>>(Messages.BrandNotListed);
                }
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandNotListed);
            }

            if (_brandDal.GetAll(filter).Count <= 0)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandNotListed);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(filter), Messages.BrandNotListed);
        }

        public IResult Add(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.BrandNotAdded);
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.BrandNotUpdated);
            }

            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }

        public IResult Delete(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.BrandNotDeleted);
            }

            _brandDal.Delete(brand);

            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}
