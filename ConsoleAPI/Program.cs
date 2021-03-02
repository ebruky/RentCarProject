using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rm = new RentalManager(new EfRentalDAL());
            Rental rental = new Rental { CarId = 2005 , CustomerId = 1, RentDate = DateTime.Now  };
            rm.Add(rental);
            Console.WriteLine(rm.Add(rental).Message);
            
            foreach (var rentals in rm.GetAll().Data)
            {
                
                Console.WriteLine(rentals.CarId);
            }
            

        }

        private static void ColorTest()
        {
            ColorManager cm = new ColorManager(new EfColorDAL());
            Color c = new Color { ColorName = "Gri" };
            cm.Add(c);
            foreach (var c1 in cm.GetAll().Data)
            {
                Console.WriteLine(c1.ColorName);

            }
            Console.WriteLine("-----------------------------------------");
            Color c2 = cm.GetById(1).Data;
            c2.ColorName = "Turkuaz";
            cm.Update(c2);
            foreach (var c1 in cm.GetAll().Data)
            {
                Console.WriteLine(c1.ColorName);

            }
            Console.WriteLine("-----------------------------------------");
            cm.Delete(c2);
            foreach (var c1 in cm.GetAll().Data)
            {
                Console.WriteLine(c1.ColorName);

            }
        }

        private static void BrandTest()
        {
            BrandManager bm = new BrandManager(new EfBrandDAL());
            Brand b1 = new Brand { BrandName = "Toyota" };
            bm.Add(b1);
            foreach (var b in bm.GetAll().Data)
            {
                Console.WriteLine(b.BrandName);
            }
            Console.WriteLine("-----------------------------------------");
            b1.BrandName = "Toyata 1";
            bm.Update(b1);
            foreach (var b in bm.GetAll().Data)
            {
                Console.WriteLine(b.BrandName);
            }
            Console.WriteLine("-----------------------------------------");
            bm.Delete(b1);
            foreach (var b in bm.GetAll().Data)
            {
                Console.WriteLine(b.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManagerr cm = new CarManagerr(new EfCarDAL());
            Car car1 = new Car { BrandId = 1, DailyPrice = 150, Description = "Citroen", ColorId = 2, ModelYear = "2014" };
            //cm.Add(car1);    //Ekleme
            //foreach (var cars in cm.GetAll())
            //{
            //    Console.WriteLine(cars.Description + "              " + cars.BrandId.ToString());
            //}
            //Console.WriteLine("-----------------------------------------");
            //car1.BrandId = 2;
            //cm.Update(car1);   //Güncelleme 

            //foreach (var cars in cm.GetAll())
            //{
            //    Console.WriteLine(cars.Description + "              " + cars.BrandId.ToString());
            //}
            //Console.WriteLine("-----------------------------------------");
            //cm.Delete(car1);    //Silme 
            //foreach (var cars in cm.GetAll())
            //{
            //    Console.WriteLine(cars.Description);
            //}
            //Console.WriteLine("-----------------------------------------");
            //var result = cm.GetById(2);
            //Console.WriteLine(result.Description);

            foreach (var cars in cm.GetCarDetails().Data)
            {
                Console.WriteLine("{0}  {1}  {2} ",cars.Description,cars.ColorName,cars.BrandName);
            }
        }

    }
    }

