using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalDetailValidator : AbstractValidator<RentalDetailDto>
    {
        public RentalDetailValidator()
        {
            RuleFor(r => r.CarName).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.CustomerName).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).Must(RentDate).WithMessage("Girilen tarih bugünün tarihinden küçük olmamalıdır!");
            RuleFor(r => r.ReturnDate).NotEmpty();

        }

        private bool RentDate(DateTime arg) 
        {
            return arg.Date >= DateTime.Today;
        }
    }
}
