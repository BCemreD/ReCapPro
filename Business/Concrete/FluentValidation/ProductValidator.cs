using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator(){
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.Name).MinimumLength(2);
     }
    }
}
