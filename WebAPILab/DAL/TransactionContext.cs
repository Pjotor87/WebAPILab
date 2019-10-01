using WebAPILab.Models;
using System.Data.Entity;

namespace WebAPILab.DAL
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public TransactionContext() : base("TransactionContext")
        {
        }
    }
}