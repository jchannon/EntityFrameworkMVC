namespace EntityFrameworkMVC.Models.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}