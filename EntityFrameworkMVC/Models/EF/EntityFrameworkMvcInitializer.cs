namespace EntityFrameworkMVC.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EntityFrameworkMvcInitializer : IDatabaseInitializer<EntityFrameworkMvcDbContext>
    {
        public void InitializeDatabase(EntityFrameworkMvcDbContext context)
        {
            if (context.Database.Exists())
            {
                context.Database.ExecuteSqlCommand("ALTER DATABASE [" + context.Database.Connection.Database +
                                                   "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                context.Database.ExecuteSqlCommand("USE master DROP DATABASE [" + context.Database.Connection.Database +
                                                   "]");
                context.Database.Delete();
            }

            context.Database.Create();

            Seed(context);
        }

        protected void Seed(EntityFrameworkMvcDbContext context)
        {
            var products = new[]
                               {
                                   new Product
                                       {
                                           ID = 1,
                                           Title = "iPad",
                                           Description = "Fruit based tablet",
                                           UnitPrice = 450
                                       },
                                   new Product
                                       {
                                           ID = 2,
                                           Title = "iPhone",
                                           Description = "Fruit based phone",
                                           UnitPrice = 500
                                       }
                               };

            foreach (Product product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            var customers = new[]
                                {
                                    new Customer
                                        {
                                            ID = 1,
                                            FirstName = "John",
                                            LastName = "Smith",
                                            EmailAddress = "john.smith@gmail.com"
                                        },
                                    new Customer
                                        {
                                            ID = 2,
                                            FirstName = "Jeff",
                                            LastName = "Jones",
                                            EmailAddress = "jeff.jones@gmail.com"
                                        }
                                };

            foreach (Customer customer in customers)
            {
                context.Customers.Add(customer);
            }

            context.SaveChanges();

            var orders = new[]
                             {
                                 new Order
                                     {
                                         ID = 1,
                                         CustomerID = 1,
                                         OrderDate = new DateTime(2013, 1, 2),
                                         ShippingAmount = 5,
                                         Products = context.Products.Where(x => x.ID == 1).ToList()
                                     },
                                 new Order
                                     {
                                         ID = 2,
                                         CustomerID = 2,
                                         OrderDate = new DateTime(2013, 2, 26),
                                         Products = context.Products.Where(x => x.ID == 1 || x.ID == 2).ToList()
                                     }
                             };

            foreach (Order order in orders)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();

            Customer firstCustomer = context.Customers.FirstOrDefault(x => x.ID == 1);
            firstCustomer.Orders = context.Orders.Where(x => x.ID == 1).ToList();

            Customer secondCustomer = context.Customers.FirstOrDefault(x => x.ID == 2);
            secondCustomer.Orders = context.Orders.Where(x => x.ID == 2).ToList();


            context.SaveChanges();
        }
    }
}