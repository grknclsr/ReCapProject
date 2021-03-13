using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarId=c.Id,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CustomerName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    } 
}

