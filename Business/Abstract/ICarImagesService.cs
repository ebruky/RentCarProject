using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);
        IDataResult<CarImages> GetById(int id);

        IDataResult<List<CarImages>> GetAllByCarId(int carId);

   
    }
}
