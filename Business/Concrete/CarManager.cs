using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter), Messages.CarGeted);
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null
                ? new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarAllNotListed)
                : new SuccessDataResult<List<Car>>(_carDal.GetAll(filter), Messages.CarAllListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            if (min > max)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarDailyPrice);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarAllListed);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), "Markaya ait arabalar listelendi.");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), "Seçilen renge göre arabalar listelendi.");
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails().Data, "Arabaların detayları listelendi.");
        }

        public IDataResult<CarDetailsDto> GetCarDetails(int id)
        {
            if (_carDal.GetCarDetails(id).Data == null)
            {
                return new ErrorDataResult<CarDetailsDto>("Arabanın detayları listelenemedi.");
            }
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetCarDetails(id).Data, "Arabanın detayları listelendi.");
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarNotAdded);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
