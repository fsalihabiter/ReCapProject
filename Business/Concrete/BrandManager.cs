using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Validation;
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

        public IDataResult<Brand> Get(int id)
        {
            if (_brandDal.Get(id) == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotGeted);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(id), Messages.BrandGeted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (_brandDal.GetAll().Count <= 0)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandNotListed);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandNotListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.BrandNotAdded);
            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
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
