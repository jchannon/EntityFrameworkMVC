namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using EntityFrameworkMVC.Models.EF;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkMvcDbContext dbContext;
        private readonly IRepoFactory repoFactory;

        public UnitOfWork(EntityFrameworkMvcDbContext dbContext, IRepoFactory repoFactory)
        {
            this.dbContext = dbContext;
            this.repoFactory = repoFactory;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Repository<T> GetRepo<T>() where T : class
        {
            return repoFactory.GetRepo<T>();
        }
    }
}