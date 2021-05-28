using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRapositoryBase<Car, CarRentalContext>, ICarDal
    {
        public IDataResult<CarDetailsDto> GetCarDetails(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == id
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                CarDetailsDto carDTO = result.FirstOrDefault();
                if (carDTO == null)
                {
                    return new ErrorDataResult<CarDetailsDto>("İstenilen öge bulunamadığı için araba detayları listelenemedi.");
                }
                return new SuccessDataResult<CarDetailsDto>(carDTO, "İstenilen öge bulunamadığı için araba detayları listelenemedi.");
            }
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.BrandId == id
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };

                List<CarDetailsDto> brandOfCarList = result.ToList();

                if (brandOfCarList.Count() <= 0)
                {
                    return new ErrorDataResult<List<CarDetailsDto>>("İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
                }
                return new SuccessDataResult<List<CarDetailsDto>>(brandOfCarList, "İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
            }
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByColorId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.ColorId == id
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };

                List<CarDetailsDto> colorOfCarList = result.ToList();

                if (colorOfCarList.Count() <= 0)
                {
                    return new ErrorDataResult<List<CarDetailsDto>>("İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
                }
                return new SuccessDataResult<List<CarDetailsDto>>(colorOfCarList, $"İstenen renge göre araba detayları listelenemedi.");
            }
        }

        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                List<CarDetailsDto> carList = result.ToList();
                if (carList.Count() <= 0)
                {
                    return new ErrorDataResult<List<CarDetailsDto>>("İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
                }
                return new SuccessDataResult<List<CarDetailsDto>>(carList, "İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
            }
        }

        public IDataResult<List<CarDetailsDto>> GetGetByDailyPrice(decimal min, decimal max)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.DailyPrice >= min && c.DailyPrice <= max
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                List<CarDetailsDto> dailyPriceOfCarList = result.ToList();
                if (dailyPriceOfCarList.Count() <= 0)
                {
                    return new ErrorDataResult<List<CarDetailsDto>>("İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
                }
                return new SuccessDataResult<List<CarDetailsDto>>(dailyPriceOfCarList, "İstenilen Araba ögesi bulunamadığı için araba detayları listelenemedi.");
            }
        }
    }
}
