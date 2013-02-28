namespace EntityFrameworkMVC.Tests
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Controllers;
    using Models;
    using Models.Repositories;
    using Xunit;

    public class ProductControllerTests
    {
        [Fact]
        public void tewwet()
        {
            var unitofWork = new Moq.Mock<IUnitOfWork>();

            unitofWork.Setup(x => x.ProductRepository.Fetch()).Returns(new[]
                                                                           {
                                                                               new Product()
                                                                                   {
                                                                                       ID = 1,
                                                                                       Title = "iPad",
                                                                                       Description =
                                                                                           "Fruit based tablet",
                                                                                       UnitPrice = 450
                                                                                   },
                                                                               new Product()
                                                                                   {
                                                                                       ID = 2,
                                                                                       Title = "iPhone",
                                                                                       Description = "Fruit based phone",
                                                                                       UnitPrice = 500
                                                                                   }
                                                                           }.AsQueryable());

            var homeController = new ProductController(unitofWork.Object);

            var result = homeController.Index() as ViewResult;

            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Create_DataPassedIn_RepositoryAddMethodCalled()
        {
            var unitofWork = new Moq.Mock<IUnitOfWork>() { };
            var prodrepo = new Moq.Mock<IRepository<Product>>();

            unitofWork.Setup(x => x.ProductRepository).Returns(prodrepo.Object);

            var controller = new ProductController(unitofWork.Object);

            var prod = new Product();

            var result = controller.Create(prod) as ViewResult;

            prodrepo.Verify(x => x.Add(prod));
        }
    }
}