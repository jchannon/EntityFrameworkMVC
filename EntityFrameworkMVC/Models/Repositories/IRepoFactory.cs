namespace EntityFrameworkMVC.Models.Repositories
{
    public interface IRepoFactory

    {
        Repository<T> GetRepo<T>() where T : class ;
    }
}