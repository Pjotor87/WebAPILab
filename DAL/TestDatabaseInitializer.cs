using System.Data.Entity;
using DAL.Seed;

namespace DAL
{
    public class TestDatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        public TestDatabaseInitializer()
        {
        }

        public TestDatabaseInitializer(DatabaseContext databaseContext)
        {
#if DEBUG
            this.InitializeDatabase(databaseContext);
#endif
        }

        protected override void Seed(DatabaseContext context)
        {
            new CustomerSeed().GetSeed().ForEach(x => context.Customers.Add(x));
            context.SaveChanges();
            new TransactionSeed().GetSeed().ForEach(x => context.Transactions.Add(x));
            context.SaveChanges();
        }
    }
}