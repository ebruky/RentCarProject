using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Concrete
{
    public class CarManagerr : ICarService
    {
        ICarDAL _icarDal;

        public CarManagerr(ICarDAL icarDal)
        {
            _icarDal = icarDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            if (car.Description.Length < 2 && car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _icarDal.Add(car);
            return new SuccessResult(Messages.Added);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 150)
            {
                throw new Exception("Fiyat 150 den küçük");
            }
            Add(car);
            return null;
        }

        public IResult Delete(Car car)
        {
            _icarDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        [PerformanceAspect(1)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_icarDal.GetAll(), Messages.ListAll);
        }



        public IDataResult<Car> GetById(int id)
        {
            return new  SuccessDataResult<Car>(_icarDal.Get(c => c.ID == id), Messages.GetById);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_icarDal.GetCarDetails(), Messages.Details);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_icarDal.GetAll(c => c.BrandId == brandId), Messages.ListOfDesiredFeature);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_icarDal.GetAll(c => c.ColorId == colorId), Messages.ListOfDesiredFeature);
        }

       public IResult Update(Car car)
        {
            _icarDal.Update(car);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
