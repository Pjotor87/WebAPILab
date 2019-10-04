using System.Data.Entity;
using Common.Models;

namespace DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<ICustomer> Customers { get; set; }
        public DbSet<ITransaction> Transactions { get; set; }

        public DatabaseContext() : base("DatabaseContext")
        {

        }
    }
}