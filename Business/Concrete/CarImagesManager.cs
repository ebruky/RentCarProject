using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDAL _carImageDal;

        public CarImagesManager(ICarImagesDAL carImageDal)
        {
            _carImageDal = carImageDal;

        }

        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageCountLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImages carImage)
        {
            IResult result = BusinessRules.Run(
                 FileHelper.DeleteAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId== carId));
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageCountLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
            
        }

        private IResult CheckIfImageCountLimit(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
