namespace EntityFrameworkMVC.Models.Repositories
{
    using EF;

    public class RepoFactory : IRepoFactory
    {
        private readonly EntityFrameworkMvcDbContext EntityFrameworkMvcDbContext;

        public RepoFactory(EntityFrameworkMvcDbContext EntityFrameworkMvcDbContext)
        {
            this.EntityFrameworkMvcDbContext = EntityFrameworkMvcDbContext;
        }

        public Repository<T> GetRepo<T>() where T : class
        {
            return new Repository<T>(EntityFrameworkMvcDbContext);
        }
    }
}