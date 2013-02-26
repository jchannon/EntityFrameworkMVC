namespace EntityFrameworkMVC.Models
{
    using System.Collections.Generic;
    using System.Data.Objects.DataClasses;

    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}