using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDAL : EfEntityRepositoryBase<Customer, CarProjectContext>, ICustomerDAL
    {
        public List<CustomerDetailDTO> GetCustomerDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result =
                             from user in context.Users
                             join customer in context.Customers
                              on user.Id equals customer.UserId
                            
                             select new CustomerDetailDTO
                             {
                                 Id = customer.Id,
                                 UserName = user.FirstName,
                                 UserLastName =user.LastName,
                                 CompanyName = customer.CompanyName,
                                 Email=user.Email
                             };

                return result.ToList();


            }
        }
    }
}
