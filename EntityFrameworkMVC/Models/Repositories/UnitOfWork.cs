namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Data.Entity;
    using System.Linq;
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

    }
}