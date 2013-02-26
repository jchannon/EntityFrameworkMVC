namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Linq;

    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Update(T entity);
        void Save();
        T FetchById(object id);
        IQueryable<T> Fetch();
    }
}