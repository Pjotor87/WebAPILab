using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPILab.Models;

namespace WebAPILab.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DatabaseContext() : base("DatabaseContext")
        {

        }
    }
}