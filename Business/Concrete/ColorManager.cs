using Business.Abstract;
using Business.Concrete.FluentValidation;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult Add(Color color)
        {
            IDataResult<ValidationResult> validationResult = ValidationTool.Validate(new ProductValidator(), new ValidationContext<Color>(color));
            if (validationResult.Success == false)
            {
                return new ErrorDataResult<ValidationResult>(validationResult.Data);
            }
          
            _colorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
