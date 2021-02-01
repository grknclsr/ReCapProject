using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{

    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id = 1,BrandId = 1, ColorId = 1, ModelYear=2000, DailyPrice = 150, Description ="Ford Focus"  },
                new Car {Id = 2,BrandId = 2, ColorId = 2, ModelYear=2001, DailyPrice = 165, Description ="AUDİ"  },
                new Car {Id = 3,BrandId = 3, ColorId = 3, ModelYear=2002, DailyPrice = 180, Description ="BMW"  },
                new Car {Id = 4,BrandId = 4, ColorId = 4, ModelYear=2003, DailyPrice = 195, Description ="Hyundai"  },
                new Car {Id = 5,BrandId = 5, ColorId = 5, ModelYear=2004, DailyPrice = 210, Description ="Opel"  }
            };
        }




        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
