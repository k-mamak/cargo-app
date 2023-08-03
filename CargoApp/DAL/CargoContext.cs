using CargoApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CargoApp.DAL
{
    public class CargoContext : DbContext
    {

        public CargoContext() : base("CargoApp")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}