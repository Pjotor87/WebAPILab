using Common.Constants.Enum;
using Common.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Transaction : ITransaction
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        [DisplayFormat(DataFormatString = "{DD/mm/YY HH:MM}")]
        public DateTime TransactionDateTime { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Amount can't have more than 2 decimal places")]
        public double Amount { get; set; }
        [MinLength(3), MaxLength(3)]
        public string CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }

        public bool IsValidCurrency(string currency)
        {
            return CurrencyHelper.GetCurrencyCodes().Contains(currency);
        }
    }
}