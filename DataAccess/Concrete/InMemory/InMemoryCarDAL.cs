using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDAL : ICarDAL
    {
        List<Car> cars;
        public InMemoryCarDAL()
        {
            cars = new List<Car> { new Car {  BrandId=1, ColorId=1, DailyPrice=68500, Description="Citroen C3", ID=1, ModelYear="2010"},
            new Car {  BrandId=1, ColorId=1, DailyPrice=100000, Description="Renault Symbol", ID=2, ModelYear="2011"},
            new Car {  BrandId=1, ColorId=1, DailyPrice=120000, Description="Renault Clio", ID=3, ModelYear="2012"},
            new Car {  BrandId=1, ColorId=1, DailyPrice=142000, Description="Dacia Stepway", ID=4, ModelYear="2014"}};

        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            var result = cars.SingleOrDefault(c => c.ID == car.ID);
            cars.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return cars.Where(c => c.ID == id).ToList();
            
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDTO GetCarDetailsById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car UpdateToCar = cars.SingleOrDefault(c => c.ID == car.ID);
            UpdateToCar.ModelYear = car.ModelYear;
            UpdateToCar.Description = car.Description;
            UpdateToCar.ColorId = car.ColorId;
            UpdateToCar.DailyPrice = car.DailyPrice;
            UpdateToCar.BrandId = car.BrandId;
        }
    }
}
