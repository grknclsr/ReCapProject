using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0 && car.Description.Length>=2)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba başarı ile eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Araba ekleme işlemi başarısız! Günlük fiyat 0'dan büyük olmalı ve araba ismi en az 2 karakterden oluşmalıdır");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c=>c.ColorId == id);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Update(car);
                Console.WriteLine("Araba başarı ile güncellendi.");
            }
            else
            {
                Console.WriteLine("Araba güncelleme işlemi başarısız! Günlük fiyat 0'dan büyük olmalı ve araba ismi en az 2 karakterden oluşmalıdır");
            }
        }
    }
}
