namespace EntityFrameworkMVC.Models
{
    using System.Collections.Generic;

    public class Customer 
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}