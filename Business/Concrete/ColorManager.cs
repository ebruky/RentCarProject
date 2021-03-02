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
    public class ColorManager : IColorService
    {
        IColorDAL _iColorDAL;

        

        public ColorManager(IColorDAL iColorDAL)
        {
            _iColorDAL = iColorDAL;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _iColorDAL.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            _iColorDAL.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_iColorDAL.GetAll(), Messages.ListAll);
            
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_iColorDAL.Get(c => c.ColorId == id),Messages.GetById);
        }

        public IResult Update(Color color)
        {
            _iColorDAL.Update(color);
            return new SuccessResult();
        }
    }
}
