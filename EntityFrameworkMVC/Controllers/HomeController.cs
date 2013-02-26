namespace EntityFrameworkMVC.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;
    using Models.Repositories;

    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> model = productRepository.Get();
            return View("Index", model);
        }
    }
}