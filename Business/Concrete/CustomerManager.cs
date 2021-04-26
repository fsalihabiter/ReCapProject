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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(Customer customer)
        {
            if (_customerDal.Delete(customer))
            {
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult(Messages.CustomerNotDeleted);
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            if (_customerDal.Get(filter) == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotGeted);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(filter), Messages.CustomerGeted);
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            if (_customerDal.GetAll(filter).Count() <= 0)
            {
                return new ErrorDataResult<List<Customer>>(Messages.CustomerNotListed);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(filter), Messages.CustomerListed);
        }

        public IResult Insert(Customer customer)
        {
            if (_customerDal.Add(customer))
            {
                return new SuccessResult(Messages.CustomerAdded);
            }
            return new ErrorResult(Messages.CustomerNotAdded);
        }

        public IResult Update(Customer customer)
        {
            if (_customerDal.Update(customer))
            {
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerNotUpdated);
        }
    }
}
