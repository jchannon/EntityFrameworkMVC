namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using EntityFrameworkMVC.Models.EF;

    public class UnitOfWork : IUnitOfWork
    {

        private readonly EntityFrameworkMvcDbContext dbContext;

        public UnitOfWork(EntityFrameworkMvcDbContext dbContext, IRepository<Product> productRepository, IRepository<Customer> customerRepository, IRepository<Order> orderRepository)
        {
            this.dbContext = dbContext;
            this.OrderRepository = orderRepository;
            this.ProductRepository = productRepository;
            this.CustomerRepository = customerRepository;
        }
        
        public IRepository<Customer> CustomerRepository { get; private set; }
        public IRepository<Product> ProductRepository { get; private set; }
        public IRepository<Order> OrderRepository { get; private set; }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

    }

    public interface IUnitOfWork
    {
        void SaveChanges();
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
    }
}