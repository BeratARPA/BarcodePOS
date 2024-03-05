using Database.Enums;
using Database.Helpers;
using Database.Models;
using System.Data.Entity;

namespace Database.Data
{
    public partial class SQLContext : DbContext
    {
        public SQLContext() : base("name=" + DatabaseType.GetConnectionString((TypeDatabase)Properties.Settings.Default.DatabaseType))
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CompanyInformation> CompanyInformations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OldCalling> OldCallings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
