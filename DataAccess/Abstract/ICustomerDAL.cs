using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDAL:IEntityRepository<Customer>
    {
        List<CustomerDetailDTO> GetCustomerDetails();
    }
}
