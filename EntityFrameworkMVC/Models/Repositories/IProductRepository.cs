namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Collections.Generic;

    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product GetById(int id);
        void SaveChanges();
        void Store(Product product);
    }
}