namespace EntityFrameworkMVC.Models.EF
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EntityFrameworkMvcDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}