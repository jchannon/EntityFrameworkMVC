namespace EntityFrameworkMVC.Models
{
    using System.Collections.Generic;

    public class OrderCustomer
    {
        public Order Order { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Customers { get; set; }
    }
}