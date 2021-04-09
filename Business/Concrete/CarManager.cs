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
            if (_carDal.Get(filter) == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotGeted);
            }
            return new SuccessDataResult<Car>(_carDal.Get(filter), Messages.CarGeted);
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            if (_carDal.GetAll(filter).Count() <= 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarAllNotListed);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter), Messages.CarAllListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            if (min < max)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarDailyPrice);
            }
            else if (_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max).Count() <= 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarAllNotListed);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarAllListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            if (_carDal.GetAll(c => c.BrandId == id).Count() <= 0)
            {
                return new ErrorDataResult<List<Car>>("Marka bulunamadığı için markaya ait arabalar listelenemedi.");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), "Markaya ait arabalar listelendi.");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            if (_carDal.GetAll(c => c.ColorId == id).Count() <= 0)
            {
                return new ErrorDataResult<List<Car>>("Renk bulunamadığı için renge göre arabalar listelenemedi.");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), "Seçilen renge göre arabalar listelendi.");
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            if (_carDal.GetCarsDetails().Data.Count() <= 0)
            {
                return new ErrorDataResult<List<CarDetailsDto>>("Arabaların detayları listelenemedi.");
            }
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
        public IResult Insert(Car car)
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
            if (_carDal.Update(car))
            {
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarNotUpdated);
        }

        public IResult Delete(Car car)
        {
            if (_carDal.Delete(car))
            {
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarNotDeleted);
        }
    }
}
