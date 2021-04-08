using Core.Utilities.Results;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.FluentValidation
{
    public class ValidationTool
    {
        public static IDataResult<ValidationResult> Validate(IValidator validator, IValidationContext entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                return new ErrorDataResult<ValidationResult>(result);
            }
            return new SuccessDataResult<ValidationResult>();
        }
    }
}
