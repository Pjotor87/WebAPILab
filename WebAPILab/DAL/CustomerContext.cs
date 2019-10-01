using WebAPILab.Models;
using System.Data.Entity;

namespace WebAPILab.DAL
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext() : base("CustomerContext")
        {
        }
    }
}