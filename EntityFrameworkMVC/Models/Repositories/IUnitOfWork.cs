namespace EntityFrameworkMVC.Models.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Repository<T> GetRepo<T>() where T : class;
    }
}