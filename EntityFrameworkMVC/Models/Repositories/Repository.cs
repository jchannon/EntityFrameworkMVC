namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DbSet<T> entitySet;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            entitySet = unitOfWork.GetEntitySet<T>();
        }

        public void Add(T entity)
        {
            entitySet.Add(entity);
            
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        public T FetchById(object id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Fetch()
        {
            return entitySet;
        }
    }
}