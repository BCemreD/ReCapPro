using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {
       
        }
        private static void rentalTest()
        {
            var rentalManager = new RentalManager(new EfRentalDal());
            var rental = new Rental
            {
                RentalId = 4,
                CustomerId = 3,
                RentDate = DateTime.Now,
                ReturnDate = null
            };
            var result = rentalManager.Add(rental);
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
                var userManager = new UserManager(new EfUserDal());
            userManager.GetAll().Data.ForEach(u => Console.WriteLine(u.FirstName));
        }
        private static void customerUser()
        {
            var customerManager = new CustomerManager(new EfCustomerDal());
            var customer = new Customer { UserId = 2, CompanyName = "Renault" };
            customerManager.Add(customer);
            customerManager.GetAll().Data.ForEach(c => Console.WriteLine(c.CustomerId+""+c.UserId+""+c.CompanyName));
        }
               
          
    }
}
