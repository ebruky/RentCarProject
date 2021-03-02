
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
    public class EfCarDAL : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDAL
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarProjectContext context=new CarProjectContext())
            {
               var result = 
                            from car in context.Cars
                            join br in context.Brands
                             on car.BrandId equals br.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             select new CarDetailDTO
                             {
                                 BrandName = br.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };

                return result.ToList();     

                           
            }

           
        }
    }
}
