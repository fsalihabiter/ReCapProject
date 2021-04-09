using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using System.Linq.Expressions;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<CarDetailsDto> GetCarDetails(int id);
    }
}
