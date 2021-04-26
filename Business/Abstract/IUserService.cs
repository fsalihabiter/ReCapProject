﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IResult Insert(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
