namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Linq;

    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Update(T entity);
        T FetchById(int id);
        IQueryable<T> Fetch();
    }
}