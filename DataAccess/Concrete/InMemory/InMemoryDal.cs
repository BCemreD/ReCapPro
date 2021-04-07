using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal:IProductDal
    {//ürünle ilgili erişim kodları (backend)
        private List<Product> _products;

        public InMemoryDal()
    {
            _products = new List<Product>
            {
                new Product{Id=1, BrandId=1, ColorId=1, DailyPrice=186000,ModelYear=2021,Description="Mavi Opel Combo"},
                new Product{Id=2, BrandId=1, ColorId=2, DailyPrice=1500000,ModelYear=2021,Description="Gri Mercedes E300"},
                new Product{Id=3, BrandId=2, ColorId=2, DailyPrice=1400000,ModelYear=2021,Description="Gri Mercedes CLA45"},
                new Product{Id=4, BrandId=3, ColorId=3, DailyPrice=300000,ModelYear=2020,Description="Turuncu Renault Captur"},
            };
     }
        
        public Product GetById(int Id)
        {
            return _products.SingleOrDefault(p => p.Id == Id);
        }
        public List<Product> GetAll()
        {
            return _products;
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        public void Delete(Product product)
        {
            Product ProductToDelete = _products.SingleOrDefault(p => p.Id == product.Id);
            _products.Remove(ProductToDelete);
        }
        public void Update(Product product)
        {
            Product ProductToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            ProductToUpdate.BrandId = product.BrandId;
            ProductToUpdate.ColorId = product.ColorId;
            ProductToUpdate.ModelYear = product.ModelYear;
            ProductToUpdate.DailyPrice = ProductToUpdate.DailyPrice;
            ProductToUpdate.Description = ProductToUpdate.Description;
        }
        public List <Product> GetAll(Expression<Func<Product, bool>> filter=null )
        {
            throw new NotImplementedException();
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
