namespace Common.Models
{
    public static class ModelFactory
    {
        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }

        public static ITransaction CreateTransaction()
        {
            return new Transaction();
        }
    }
}
