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
    public class EfCustomerDal : EfEntityRapositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public IDataResult<CustomerDetailDto> GetCustomerDetail(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             where c.Id == id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 User = u.FirstName + " " + u.LastName,
                                 CompanyName = c.CompanyName
                             };
                CustomerDetailDto customer = result.FirstOrDefault();
                if (customer == null)
                {
                    return new ErrorDataResult<CustomerDetailDto>("İstenilen müşteri ögesi bulunamadığı için müşteri detayları listelenemedi.");
                }
                return new SuccessDataResult<CustomerDetailDto>(customer, "İstenilen müşteri ögesi bulunamadığı için müşteri detayları listelenemedi.");
            }
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomersDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 User = u.FirstName + " " + u.LastName,
                                 CompanyName = c.CompanyName
                             };
                List<CustomerDetailDto> customerList = result.ToList();
                if (customerList.Count() <= 0)
                {
                    return new ErrorDataResult<List<CustomerDetailDto>>("İstenilen müşteri ögesi bulunamadığı için müşteri detayları listelenemedi.");
                }
                return new SuccessDataResult<List<CustomerDetailDto>>(customerList, "İstenilen müşteri ögesi bulunamadığı için müşteri detayları listelenemedi.");
            }
        }
    }
}
