using Models;
using System.Data.Entity;

namespace DAL
{
    public interface IDatabaseContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}