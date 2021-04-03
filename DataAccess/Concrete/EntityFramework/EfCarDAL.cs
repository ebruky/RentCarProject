
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDAL : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDAL
    {
        public List<CarDetailDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarProjectContext context=new CarProjectContext())
            {
                var result =
                             from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                              on car.BrandId equals br.BrandId
                             join col in context.Colors
                            on car.ColorId equals col.ColorId
                            
                             select new CarDetailDTO
                             { Id = car.ID,
                                 BrandName = br.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ImagePath= @"\images\default.jfif",
                                 CarImages = new List<CarImages>()
            };

                return result.ToList();     

                           
            }

           
        }

        public CarDetailDTO GetCarDetailsById(Expression<Func<Car, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result =
                             from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                              on car.BrandId equals br.BrandId
                             join col in context.Colors
                            on car.ColorId equals col.ColorId
                             
                             select new CarDetailDTO
                             {
                                 Id = car.ID,
                                 BrandName = br.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ImagePath = @"\images\default.jfif",
                                 CarImages = new List<CarImages>()
                             };

                return result.FirstOrDefault();


            }
        }
    }
}
