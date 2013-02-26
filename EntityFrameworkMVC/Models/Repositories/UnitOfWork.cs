namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Data.Entity;
    using EntityFrameworkMVC.Models.EF;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkMvcDbContext dbContext;

        public UnitOfWork(EntityFrameworkMvcDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public IRepository<Customer> customerRepository { get; set; }
        public IRepository<Product> productRepository { get; set; }
        public IRepository<Order> orderRepository { get; set; }

        public DbSet<TEntity> GetEntitySet<TEntity>() where TEntity : class
        {
            return dbContext.Set<TEntity>();
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
        IRepository<Customer> customerRepository { get; set; }
        IRepository<Product> productRepository { get; set; }
        IRepository<Order> orderRepository { get; set; } 
        DbSet<TEntity> GetEntitySet<TEntity>() where TEntity : class;
    }
}