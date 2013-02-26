namespace EntityFrameworkMVC.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;
    using Models.Repositories;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}