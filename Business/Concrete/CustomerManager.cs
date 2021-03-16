using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDAL _iCustomerDal;

        public CustomerManager(ICustomerDAL iCustomerDal)
        {
            _iCustomerDal = iCustomerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _iCustomerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _iCustomerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_iCustomerDal.GetAll(), Messages.ListAll);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_iCustomerDal.Get(c=>c.Id==id), Messages.GetById);
        }

        public IDataResult<List<CustomerDetailDTO>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDTO>>(_iCustomerDal.GetCustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            _iCustomerDal.Update(customer);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
