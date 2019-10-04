namespace DAL.Seed
{
    public static class SeedFactory
    {
        public static CustomerSeed CreateCustomerSeed()
        {
            return new CustomerSeed();
        }

        public static TransactionSeed CreateTransactionSeed()
        {
            return new TransactionSeed();
        }
    }
}