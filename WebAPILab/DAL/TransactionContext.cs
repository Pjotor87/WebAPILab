using WebAPILab.Models;
using System.Data.Entity;

namespace WebAPILab.DAL
{
    public class TransactionContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public TransactionContext() : base("TransactionContext")
        {
        }
    }
}