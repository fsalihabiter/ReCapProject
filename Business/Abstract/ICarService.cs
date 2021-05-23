using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null);
        IDataResult<Car> Get(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<CarDetailsDto> GetCarDetails(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

    }
}
