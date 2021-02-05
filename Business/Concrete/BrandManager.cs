using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka başarı ile eklendi.");
            }
            else
            {
                Console.WriteLine("Marka ekleme işlemi başarısız! Marka ismi en az 2 karakterden oluşmalıdır.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka başarı ile güncellendi.");
            }
            else
            {
                Console.WriteLine("Marka güncelleme işlemi başarısız! Marka ismi en az 2 karakterden oluşmalıdır.");
            }
        }
    }
}
