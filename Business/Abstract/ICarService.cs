using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDTO>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDTO>> GetFilterCar(int brandId, int colorId);

        IDataResult<List<CarDetailDTO>> GetCarDetails();

        IDataResult<CarDetailDTO> GetCarDetailsById(int id);
        IResult AddTransactionalTest(Car car);
    }
}
