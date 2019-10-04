using System.Collections.Generic;

namespace Common.Models
{
    public interface ICustomer
    {
        string CustomerEmail { get; set; }
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        int Id { get; set; }
        double MobileNo { get; set; }
        string TransactionIds { get; set; }
        IList<ITransaction> Transactions { get; set; }

        IList<ITransaction> GetMostRecentTransactions(int take);
        void PopulateTransactions(IList<ITransaction> transactions);
        void SetMostRecentTransactions(int take);
    }
}