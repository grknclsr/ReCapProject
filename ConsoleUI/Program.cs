using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************ARABALAR****************");
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + "/" + car.Description + "/" + car.ColorName + "/" + car.BrandName + "/" + car.ModelYear);
            }
            //carManager.Add(new Car { BrandId = 7,ColorId=9,ModelYear=2014,DailyPrice=143,Description="Chevrolet" });
            //carManager.Update(new Car { Id = 2002,BrandId = 5, ColorId = 8, ModelYear = 1978, DailyPrice = 105, Description = "Murat 131" });
            //carManager.Delete(new Car { Id = 1003 });

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("****************RENKLER****************");
            //colorManager.Add(new Color { ColorName = "Dark Blue" });
            //colorManager.Add(new Color { ColorName = "Dark Green" });
            //colorManager.Update(new Color { ColorId = 12, ColorName = "Dark Yellow" });
            //colorManager.Delete(new Color { ColorId = 14 });

            //foreach (var colors in colorManager.GetAll())
            //{
            //    Console.WriteLine(colors.ColorName);
            //}

            //Console.WriteLine("****************MARKALAR****************");

            //brandManager.Add(new Brand { BrandName = "Honda" });
            //brandManager.Add(new Brand { BrandName = "Honda2" });
            //brandManager.Update(new Brand { BrandId = 7, BrandName = "Şahin" });
            //brandManager.Delete(new Brand { BrandId = 8 });

            //foreach (var brands in brandManager.GetAll())
            //{
            //    Console.WriteLine(brands.BrandName);
            //}


        }
    }
}
