using Microsoft.Data.Entity;

namespace DAL.Models
{
    public class NorthwindContextBase : DbContext
    {
        public NorthwindContextBase()
            : base()
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        //public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        //public DbSet<Regions> Regions { get; set; }
        //public DbSet<Shippers> Shippers { get; set; }
        //public DbSet<Suppliers> Suppliers { get; set; }
        //public DbSet<Territories> Territories { get; set; }

        protected override void OnModelCreating(ModelBuilder md)
        {
            base.OnModelCreating(md);

            //md.Entity<EmployeeTerritories>().HasKey(x => new { x.EmployeeId, x.TerritoryId });
            md.Entity<OrderDetails>().HasKey(t => new { t.OrderID, t.ProductID });
        }
    }
}
