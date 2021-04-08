﻿using Business.Abstract;
using Business.Concrete.FluentValidation;
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

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), new ValidationContext<Product>(product));
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }


        public void Update(Product product)
        {
            _productDal.Update(product);
        }
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }
       public List<Product>GetByBrandId(int id)
        {
            return _productDal.GetAll(p => p.BrandId == id);
        }
       public List<Product> GetByColorId(int id)
        {
            return _productDal.GetAll(p => p.ColorId == id);
        }
        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
