using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IDataResult<List<RentalDetailDto>> GetRentalsDetail();
        IDataResult<RentalDetailDto> GetRentalDetail(int id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult ReturnCarAdded(Rental rental, DateTime returnDate);
    }
}
