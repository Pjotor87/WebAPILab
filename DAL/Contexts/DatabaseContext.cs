﻿using System.Data.Entity;
using Models;

namespace DAL.Contexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DatabaseContext() : base("DatabaseContext")
        {

        }
    }
}