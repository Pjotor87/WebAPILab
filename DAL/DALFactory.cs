namespace DAL
{
    public static class Factory
    {
        public static IDatabaseContext CreateDatabaseContext()
        {
            return new DatabaseContext();
        }
    }
}