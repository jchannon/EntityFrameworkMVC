namespace EntityFrameworkMVC.Models.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class ProductRepository : IProductRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> Get()
        {
            return unitOfWork.DbContext.Products;
        }

        public Product GetById(int id)
        {
            return unitOfWork.DbContext.Products.FirstOrDefault(x => x.ID == id);
        }

        public void SaveChanges()
        {
            unitOfWork.DbContext.SaveChanges();
        }

        public void Store(Product product)
        {
            unitOfWork.DbContext.Products.Add(product);
        }
    }
}