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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<Color> Get(Expression<Func<Color, bool>> filter)
        {
            if (_colorDal.Get(filter) == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotGeted);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(filter), Messages.ColorGeted);
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            if (_colorDal.GetAll(filter) == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotGeted);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(filter), Messages.ColorGeted);
        }

        public IResult Insert(Color color)
        {
            if (_colorDal.Add(color))
            {
                return new SuccessResult(Messages.ColorAdded);
            }
            return new ErrorResult(Messages.ColorNotAdded);
        }

        public IResult Update(Color color)
        {
            if (_colorDal.Update(color))
            {
                return new SuccessResult(Messages.ColorUpdated);
            }
            return new ErrorResult(Messages.ColorNotUpdated);
        }

        public IResult Delete(Color color)
        {
            if (_colorDal.Delete(color))
            {
                return new SuccessResult(Messages.ColorDeleted);
            }
            return new ErrorResult(Messages.ColorNotDeleted);
        }
    }
}
