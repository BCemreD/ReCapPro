using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Utilities.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator(){
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Daily price must be grater then 0.");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("The product's name must be at least 2 characters.");
        }
    }
}
