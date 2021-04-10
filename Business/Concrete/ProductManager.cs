using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Concrete.FluentValidation;
using Business.Constants;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product>GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }
        public IDataResult<List<Product>>GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetails(){
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]

        [SecuredOperation("product.add,moderator,admin")]
        public IResult Add(Product product)
        {
           _productDal.Add(product);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("product.delete,moderator,admin")]
        public IResult Delete(Product product)
        {
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("product.update,moderator,admin")]
        public IResult Update(Product product)
        {
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Product>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Product>> GetByColorId(int id)
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ColorId == id));
        }
    }
}
