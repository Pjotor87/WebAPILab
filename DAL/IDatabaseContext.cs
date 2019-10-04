using System.Data.Entity;
using Common.Models;

namespace DAL
{
    public interface IDatabaseContext
    {
        DbSet<ICustomer> Customers { get; set; }
        DbSet<ITransaction> Transactions { get; set; }
    }
}