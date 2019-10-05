using System.Data.Entity;
using DAL.Contexts;
using DAL.Seed;

namespace DAL.Initializers
{
    public class TestDatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        private readonly ICustomerSeed CustomerSeed;
        private readonly ITransactionSeed TransactionSeed;

        public TestDatabaseInitializer(ICustomerSeed customerSeed, ITransactionSeed transactionSeed)
        {
            CustomerSeed = customerSeed;
            TransactionSeed = transactionSeed;
        }

        protected override void Seed(DatabaseContext dbContext)
        {
            CustomerSeed.GetSeed().ForEach(x => dbContext.Customers.Add(x));
            dbContext.SaveChanges();
            TransactionSeed.GetSeed().ForEach(x => dbContext.Transactions.Add(x));
            dbContext.SaveChanges();
        }
    }
}