namespace DAL.Seed
{
    public static class SeedFactory
    {
        public static ICustomerSeed CreateCustomerSeed()
        {
            return new CustomerSeed();
        }

        public static ITransactionSeed CreateTransactionSeed()
        {
            return new TransactionSeed();
        }
    }
}