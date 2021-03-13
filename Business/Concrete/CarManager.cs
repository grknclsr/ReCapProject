using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.add,admin")]
        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.add,admin")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
        }
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result>=2)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
    }
}
