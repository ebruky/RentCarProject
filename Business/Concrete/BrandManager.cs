using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDAL _iBrandDAL;

        public BrandManager(IBrandDAL iBrandDAL)
        {
            _iBrandDAL = iBrandDAL;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _iBrandDAL.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            _iBrandDAL.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDAL.GetAll(), Messages.ListAll);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_iBrandDAL.Get(b => b.BrandId == id), Messages.GetById);
        }

        public IResult Update(Brand brand)
        {
            _iBrandDAL.Update(brand);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
