using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class RentalValidator : AbstractValidator<Rental>
    { 
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.RentDate).Must(RentDateInvalid).WithMessage("Teslim edilen tarih bugünden küçük veya bugüne eşit olmalı");
            RuleFor(r => r.CustomerId).NotEmpty();
           
        }

        private bool RentDateInvalid(DateTime arg)
        {
            return   arg.Date <= DateTime.Today;
        }

        
    }
}
