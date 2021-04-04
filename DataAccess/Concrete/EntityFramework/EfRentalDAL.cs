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
    public class EfRentalDAL : EfEntityRepositoryBase<Rental, CarProjectContext>, IRentalDAL
    {
        public List<RentalDetailDTO> GetRentalDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result =
                             from rental in context.Rentals
                             join customer in context.Customers
                              on rental.CustomerId equals customer.Id
                              join user in context.Users
                              on customer.UserId equals user.Id
                              join car in context.Cars
                              on rental.CarId equals car.ID
                              join brand in context.Brands
                              on car.BrandId equals brand.BrandId

                             select new RentalDetailDTO
                             {
                                 Id = rental.Id,
                                 BrandName =brand.BrandName ,
                                 UserNameLastName = user.FirstName+user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate =rental.ReturnDate,
                                 CarId=car.ID,
                                 TotalPrice=0
                             };

                return result.ToList();


            }
        }
    }
}
