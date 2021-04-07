using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());      

            Product product = new Product
            { Name="Renault", Id = 5, BrandId = 3, ColorId = 1, ModelYear = 2020, DailyPrice = 340000, Description = "Mavi Renault Zoe" };
            productManager.Add(product);
            productManager.GetAll().ForEach(p => Console.WriteLine(p.Name));
          




        }
    }
}
