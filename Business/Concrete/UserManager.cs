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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Delete(User user)
        {
            if (_userDal.Delete(user))
            {
                return new SuccessResult(Messages.UserDeleted);
            }
            return new ErrorResult(Messages.UserNotDeleted);
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            if (_userDal.Get(filter) == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotGeted);
            }
            return new SuccessDataResult<User>(_userDal.Get(filter), Messages.UserGeted);
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            if (_userDal.GetAll(filter).Count() <= 0)
            {
                return new ErrorDataResult<List<User>>(Messages.UserNotListed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter), Messages.UserListed);
        }

        public IResult Insert(User user)
        {
            if (_userDal.Add(user))
            {
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.UserNotAdded);
        }

        public IResult Update(User user)
        {
            if (_userDal.Update(user))
            {
                return new SuccessResult(Messages.UserUpdated);
            }
            return new ErrorResult(Messages.UserNotUpdated);
        }
    }
}
