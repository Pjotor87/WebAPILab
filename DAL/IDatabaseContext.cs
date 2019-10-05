using System.Data.Entity;
using Models;

namespace DAL
{
    public interface IDatabaseContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}