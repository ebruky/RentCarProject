using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDAL:IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDTO GetCarDetailsById(Expression<Func<Car, bool>> filter = null);
    }
}
