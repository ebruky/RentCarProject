using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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
        IUserDAL _userDal;

        public UserManager(IUserDAL userDal)
        {
            _userDal = userDal;
        }

       
       

        
        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id==id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            
            return new  SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

       

        public IDataResult<User> GetByMail(string email)
        {
            
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
    }
}
