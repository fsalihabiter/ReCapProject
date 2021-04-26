using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental rental)
        {
            if (_rentalDal.Delete(rental))
            {
                return new SuccessResult(Messages.RentalDeleted);
            }
            return new ErrorResult(Messages.RentalNotDeleted);
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            if (_rentalDal.Get(filter) == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotGeted);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter), Messages.RentalGeted);
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            if (_rentalDal.GetAll(filter).Count() <= 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalNotListed);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter), Messages.RentalListed);
        }

        public IResult Insert(Rental rental)
        {
            if (_rentalDal.Add(rental))
            {
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalNotAdded);
        }

        public IResult ReturnCarAdded(Rental rental, DateTime returnDate)
        {
            if (returnDate != null && rental != null)
            {
                rental.ReturnDate = returnDate;
                var result = Update(rental);
                if (result.Success)
                {
                    return new SuccessResult(Messages.ReturnDateAdded);
                }
                return new ErrorResult(Messages.ReturnDateNotAdded);
            }
            return new ErrorResult(Messages.ValueblesInvalid);
        }

        public IResult Update(Rental rental)
        {
            if (_rentalDal.Update(rental))
            {
                return new SuccessResult(Messages.RentalUpdated);
            }
            return new ErrorResult(Messages.RentalNotUpdated);
        }
    }
}
