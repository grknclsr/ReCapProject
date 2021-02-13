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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Console.WriteLine("****************ARABALAR****************");
            //carManager.Add(new Car { BrandId = 7, ColorId = 9, ModelYear = 2014, DailyPrice = 143, Description = "Chevrolet" });
            //carManager.Update(new Car { Id = 3002, BrandId = 5, ColorId = 8, ModelYear = 1978, DailyPrice = 105, Description = "Doğan SLX" });
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

            Console.WriteLine("****************MÜŞTERİLER****************");
            //customerManager.Add(new Customer { CompanyName = "Sebahat Holding" ,UserId=1003});
            //customerManager.Update(new Customer { Id=1002,UserId = 1003,CompanyName="Sebahat Çalışır Holding"});
            //customerManager.Delete(new Customer { Id = 1002});
            CustomerListed(customerManager);

            Console.WriteLine("****************KİRALAR****************");
            //rentalManager.Add(new Rental{CustomerId =1003,CarId=6,RentDate=new DateTime(2020,12,15),ReturnDate=new DateTime(2021,01,05)});
            //rentalManager.Update(new Rental { Id=1002,CustomerId = 1003, CarId = 6, RentDate = new DateTime(2020, 12, 15), ReturnDate = new DateTime(2021, 01, 08) });
            //rentalManager.Delete(new Rental { Id = 1002 });
            RentalListed(rentalManager);

            Console.WriteLine("****************KULLANICILAR****************");
            //userManager.Add(new User { FirstName = "Sebahat" ,LastName="Çalışır",Email="sebahatcalisir@gmail.com",Password="111111"});
            //userManager.Update(new User { Id = 1002, FirstName = "Sebahat", LastName = "Çalışır", Email = "sebahatcalisir@gmail.com", Password = "222222"});
            //userManager.Delete(new User { Id = 1004 });
            UserListed(userManager);


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
        private static void CustomerListed(CustomerManager customerManager)
        {
            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void UserListed(UserManager userManager)
        {
            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.Id+"/" + user.FirstName+"/"+user.LastName+ "/"+user.Email+ "/"+user.Password);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void RentalListed(RentalManager rentalManager)
        {
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Rental Id: "+rental.Id+ " "+ "Rental CustomerId: "+rental.CustomerId+ " "+"Rental CarId: "+rental.CarId+" "+
                        "Rent Date: "+rental.RentDate+" "+"Rent Return Date: "+rental.ReturnDate);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
