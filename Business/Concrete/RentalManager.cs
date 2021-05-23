﻿using Business.Abstract;
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
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter), Messages.RentalGeted);
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return filter == null
                ? new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalNotListed)
                : new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter), Messages.RentalListed);
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult ReturnCarAdded(Rental rental, DateTime returnDate)
        {
            if (returnDate != null && rental != null)
            {
                rental.ReturnDate = returnDate;
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.ReturnDateAdded);
            }
            return new ErrorResult(Messages.ValueblesInvalid);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}