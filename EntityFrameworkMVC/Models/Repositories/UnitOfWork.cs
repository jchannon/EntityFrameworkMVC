namespace EntityFrameworkMVC.Models.Repositories
{
    using EF;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkMvcDbContext dbContext;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Customer> customerRepository;

        public UnitOfWork(EntityFrameworkMvcDbContext dbContext, IRepository<Product> productRepository, IRepository<Customer> customerRepository, IRepository<Order> orderRepository)
        {
            this.dbContext = dbContext;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.customerRepository = customerRepository;
        }

        public IRepository<Customer> CustomerRepository { get { return customerRepository; } }
        public IRepository<Product> ProductRepository { get { return productRepository; } }
        public IRepository<Order> OrderRepository { get { return orderRepository; } }

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