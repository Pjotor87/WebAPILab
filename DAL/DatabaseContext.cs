﻿using System.Data.Entity;
using Common.Models;

namespace DAL
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