using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Concrete.FluentValidation;
using Business.Constants;
using Core.Utilities.Results;
using Core.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
       private readonly  IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<Brand> GetById(int id)
        {

            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IDataResult<List<Brand>> GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        [SecuredOperation("rental.add,moderator,admin")]
        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new ProductValidator(), new ValidationContext<Brand>(brand));
         

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("rental.update,moderator,admin")]
        public IResult Update(Brand brand)
        {
      

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        [SecuredOperation("rental.delete,moderator,admin")]
        public IResult Delete(Brand brand)
        {
     

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}
