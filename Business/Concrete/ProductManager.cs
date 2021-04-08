using Business.Abstract;
using Business.Concrete.FluentValidation;
using Business.Constants;
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
        private IProductDal _productDal;
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

        public IResult Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), new ValidationContext<Product>(product));
            _productDal.Add(product);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Product product)
        {
            return new SuccessResult(Messages.CarDeleted);
        }

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
