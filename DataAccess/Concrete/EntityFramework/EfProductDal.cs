using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ProductContext>,IProductDal
    {
       public List<ProductDetailDto> GetProductDetails()
        {
            using (var context = new ProductContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands on p.BrandId equals b.BrandId
                             join c in context.Colors on p.ColorId equals c.ColorId
                             select new ProductDetailDto
                             {
                                 Name = p.Name,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
