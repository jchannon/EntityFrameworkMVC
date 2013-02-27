namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using EF;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EntityFrameworkMvcDbContext context;
        private readonly DbSet<T> entitySet;

        public Repository(EntityFrameworkMvcDbContext context)
        {
            this.context = context;
            entitySet = context.Set<T>();
        }

        public void Add(T entity)
        {
            entitySet.Add(entity);
            
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public T FetchById(int id)
        {
            return entitySet.Find(id);
        }

        public IQueryable<T> Fetch()
        {
            return entitySet;
        }
    }
}