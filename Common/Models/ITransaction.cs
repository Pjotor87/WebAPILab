using System;
using Common.Constants.Enum;

namespace Common.Models
{
    public interface ITransaction
    {
        double Amount { get; set; }
        string CurrencyCode { get; set; }
        int Id { get; set; }
        TransactionStatus Status { get; set; }
        DateTime TransactionDateTime { get; set; }
        int TransactionId { get; set; }

        bool IsValidCurrency(string currency);
    }
}