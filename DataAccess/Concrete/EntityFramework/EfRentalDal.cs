using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRapositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public IDataResult<RentalDetailDto> GetRentalDetail(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             where r.Id == id
                             select new RentalDetailDto
                             {
                                 Id = c.Id,
                                 Customer = u.FirstName + " " + u.LastName,
                                 Car = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                RentalDetailDto rental = result.FirstOrDefault();
                if (rental == null)
                {
                    return new ErrorDataResult<RentalDetailDto>("İstenilen kiralama ögesi bulunamadığı için kiralama detayları listelenemedi.");
                }
                return new SuccessDataResult<RentalDetailDto>(rental, "İstenilen kiralama ögesi bulunamadığı için kiralama detayları listelenemedi.");
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = c.Id,
                                 Customer = u.FirstName + " " + u.LastName,
                                 Car = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                List<RentalDetailDto> rentalList = result.ToList();
                if (rentalList.Count() <= 0)
                {
                    return new ErrorDataResult<List<RentalDetailDto>>("İstenilen kiralama ögesi bulunamadığı için kiralama detayları listelenemedi.");
                }
                return new SuccessDataResult<List<RentalDetailDto>>(rentalList, "İstenilen kiralama ögesi bulunamadığı için kiralama detayları listelenemedi.");
            }
        }
    }
}
