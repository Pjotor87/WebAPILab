namespace WebAPILab
{
    public sealed class Constants
    {
        public sealed class Swagger
        {
            public const string RELATIVE_URL = "/swagger/ui/index";
        }

        public sealed class Search
        {
            public const int DEFAULT_TRANSACTIONS_TAKE = 5;
            public const string RESPONSE_FORMAT = "application/json";
            public sealed class ErrorMessages
            {
                public const string NOT_FOUND = "Not found";
                public const string BAD_EMAIL = "Invalid Email";
                public const string BAD_CUSTOMERID = "Invalid Customer ID";
                public const string NOSEARCHCRITERIA = "No inquiry criteria";
            }
        }
    }
}