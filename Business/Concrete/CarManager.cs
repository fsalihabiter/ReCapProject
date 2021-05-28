using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Validation;
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

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(id), Messages.CarGeted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarAllNotListed);
        }

        public IDataResult<List<CarDetailsDto>> GetByDailyPrice(decimal min, decimal max)
        {
            if (min > max)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.CarDailyPrice);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetGetByDailyPrice(min, max).Data, Messages.CarAllListed);
            }
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsByBrandId(id).Data, "Markaya ait arabalar listelendi.");
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsByColorId(id).Data, "Seçilen renge göre arabalar listelendi.");
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarNotAdded);
        }


        [ValidationAspect(typeof(CarValidator))]
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
