using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (ProductContext context = new ProductContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (ProductContext context = new ProductContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (ProductContext context = new ProductContext())
            {
                   return filter == null
                    ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
                
            }
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (ProductContext context = new ProductContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }


        public void Update(Product entity)
        {
            using (ProductContext context = new ProductContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
