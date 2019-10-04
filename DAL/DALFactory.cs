namespace DAL
{
    public static class DALFactory
    {
        public static IDatabaseContext CreateDatabaseContext()
        {
            return new DatabaseContext();
        }
    }
}