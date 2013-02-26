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

        public DbSet<TEntity> GetEntitySet<TEntity>() where TEntity : class
        {
            return dbContext.Set<TEntity>();
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
        DbSet<TEntity> GetEntitySet<TEntity>() where TEntity : class;
    }
}