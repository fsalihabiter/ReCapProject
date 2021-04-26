using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null);
        IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter);
        IResult Insert(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
