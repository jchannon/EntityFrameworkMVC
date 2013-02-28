namespace EntityFrameworkMVC.Tests
{
    using System.Linq;
    using System.Web.Mvc;
    using Controllers;
    using Models;
    using Models.Repositories;
    using Xunit;

    public class HomeControllerTests
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
    }
}