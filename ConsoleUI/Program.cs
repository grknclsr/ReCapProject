using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İlk Liste");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id: " + car.Id + "  " + "Araba Color Id: " + car.ColorId + "  " + "Araba Marka Id: " + car.BrandId +
                    "  " + "Günlük araba fiyatı: " + car.DailyPrice + "  " + "Araba İsmi: " + car.Description + "  " + "Arabanın üretim tarihi: " + car.ModelYear + "\n");
            }

            Console.WriteLine("*****************");
            InMemoryCarDal memoryCarDal = new InMemoryCarDal();

            var car1 = new Car { Id = 6, ColorId = 6, BrandId = 6, DailyPrice = 150, Description = "Tesla Model X", ModelYear = 2021 };
            var car2 = new Car { Id = 7, ColorId = 5, BrandId = 1, DailyPrice = 178, Description = "For Focus 2", ModelYear = 2020 };
            memoryCarDal.Add(car1);
            memoryCarDal.Add(car2);
            memoryCarDal.Delete(new Car { Id = 1 });
            memoryCarDal.Update(new Car {Id = 3, ColorId = 3, BrandId = 3, DailyPrice = 375, Description = "BMW", ModelYear = 2002});
            memoryCarDal.GetById(5);

            Console.WriteLine("Güncel Liste");
            foreach (var cars2 in memoryCarDal.GetAll())
            {
                Console.WriteLine("Araba Id: "+cars2.Id + "  " + "Araba Color Id: " + cars2.ColorId+ "  "+ "Araba Marka Id: "+ cars2.BrandId+
                    "  " + "Günlük araba fiyatı: "+ cars2.DailyPrice+"  " + "Araba İsmi: " +cars2.Description+ "  " + "Arabanın üretim tarihi: "+ cars2.ModelYear+ "\n");
            }

        }
    }
}
