namespace EntityFrameworkMVC.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int CustomerID { get; set; }
        public int BillToAddressID { get; set; }
        public int ShipToAddressID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        public virtual Customer Customer { get; set; }
    }
}