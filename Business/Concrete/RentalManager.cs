using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDAL _irentalDal;

        public RentalManager(IRentalDAL irentalDal)
        {
            _irentalDal = irentalDal;
        }
        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //if (CheckCar(rental.CarId).Success)
            //{
            //    if(!CheckReturnDate(rental.CarId).Success)

            //    return new ErrorResult(Messages.NotAdded);
            //}
            
            _irentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult CheckCar(int carId)
        {
            var result = _irentalDal.GetAll();
            foreach (var rental in result)
            {
                if (rental.CarId == carId)
                {

                    if (CheckReturnDate(carId).Success)
                    {
                        return new SuccessResult("Araç Kiralanabilir");

                    }
                    return new ErrorResult("Araç Kiralanamaz");
                }

            }
            
          return new SuccessResult("Araç Kiralanabilir");
           

        }

         private  IResult CheckReturnDate(int carId)
         {
          

            var result = _irentalDal.GetAll(c => c.CarId == carId).LastOrDefault();
            
            
            if (result.ReturnDate!=null)
            {
                return new SuccessResult();
            }


            return new ErrorResult();
         }

        public IResult Delete(Rental rental)
        {
            _irentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_irentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_irentalDal.Get(r=>r.Id==id));
        }

        public IDataResult<List<RentalDetailDTO>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_irentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _irentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
