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
    public class UserManager : IUserService

    {
        IUserDAL _iuserDal;

        public UserManager(IUserDAL iuserDal)
        {
            _iuserDal = iuserDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _iuserDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _iuserDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_iuserDal.GetAll(),Messages.ListAll);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_iuserDal.Get(u=>u.Id==id),Messages.GetById);
        }

        public IResult Update(User user)
        {
            _iuserDal.Update(user);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
