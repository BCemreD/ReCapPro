using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {

            //Product product = new Product
            //{ Name = "Renault", Id = 5, BrandId = 3, ColorId = 1, ModelYear = 2020, DailyPrice = 340000, Description = "Mavi Renault Zoe" };
           
            //productManager.GetAll().ForEach(p => Console.WriteLine(p.Name));
            //productManager.GetProductDetails().ForEach(p => Console.WriteLine("{0}{1}{2}{3}", p.Name, p.BrandName, p.ColorName, p.DailyPrice));
                   
        }
        private static void rentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental
            {
                RentalId = 4,
                CustomerId = 3,
                RentDate = DateTime.Now,
                ReturnDate = null
            };
            IResult result = rentalManager.Add(rental);
            if (!result.Success) Console.WriteLine(result.Message);
            rentalManager.GetAll().Data.ForEach(r => Console.WriteLine(r.RentalId + " " + r.RentDate));
        }
        private static void productTest()
            {
                ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.GetProductDetails().Data.ForEach(p => 
            Console.WriteLine("{0}{1}{2}{3}", p.Name, p.BrandName, p.ColorName, p.DailyPrice));

        }
        private static void userTest()
            {
                UserManager userManager = new UserManager(new EfUserDal()); 
            }
        private static void customerUser()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { UserId = 2, CompanyName = "Renault" };
            customerManager.Add(customer);
            customerManager.GetAll().Data.ForEach(c => Console.WriteLine(c.CompanyName));
        }
               
          
    }
}
