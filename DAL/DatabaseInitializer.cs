using System.Collections.Generic;
using System.Data.Entity;
using DAL.Seed;
using Common.Models;

namespace DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        public DatabaseInitializer()
        {
        }

        public DatabaseInitializer(DatabaseContext databaseContext)
        {
#if DEBUG
            this.InitializeDatabase(databaseContext);
#endif
        }

        protected override void Seed(DatabaseContext context)
        {
            List<Customer> customerSeed = new CustomerSeed().GetSeed();
            customerSeed.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();
            List<Transaction> transactionSeed = new TransactionSeed().GetSeed();
            transactionSeed.ForEach(x => context.Transactions.Add(x));
            context.SaveChanges();
        }
    }
}