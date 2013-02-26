namespace EntityFrameworkMVC.Models.Repositories
{
    using EntityFrameworkMVC.Models.EF;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkMvcDbContext dbContext;

        public UnitOfWork(EntityFrameworkMvcDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EntityFrameworkMvcDbContext DbContext
        {
            get { return dbContext; }
        }
    }

    public interface IUnitOfWork
    {
        EntityFrameworkMvcDbContext DbContext { get; }
    }
}