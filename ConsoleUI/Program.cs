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
            
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("****************ARABALAR****************");
            //carManager.Add(new Car { BrandId = 7,ColorId=9,ModelYear=2014,DailyPrice=143,Description="Chevrolet" });
            //carManager.Update(new Car { Id = 3002,BrandId = 5, ColorId = 8, ModelYear = 1978, DailyPrice = 105, Description = "Doğan SLX" });
            //carManager.Delete(new Car { Id = 3002 });
            CarListed(carManager);

            Console.WriteLine("****************RENKLER****************");
            //colorManager.Add(new Color { ColorName = "Dark Red" });
            //colorManager.Update(new Color { ColorId = 1013, ColorName = "Dark Yellow" });
            //colorManager.Delete(new Color { ColorId = 12 });
            ColorListed(colorManager);

            Console.WriteLine("****************MARKALAR****************");
            //brandManager.Add(new Brand { BrandName = "Ş" });
            //brandManager.Update(new Brand { BrandId = 7, BrandName = "Doğan" });
            //brandManager.Delete(new Brand { BrandId = 1006 });
            BrandListed(brandManager);


        }

        private static void CarListed(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + "/" + car.Description + "/" + car.ColorName + "/" + car.BrandName + "/" + car.ModelYear);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorListed(ColorManager colorManager)
        {
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void BrandListed(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
