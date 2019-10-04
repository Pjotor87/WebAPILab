using System;
using System.Collections.Generic;
using Common.Models;

namespace DAL.Seed
{
    public class TransactionSeed
    {
        public List<Transaction> GetSeed()
        {
            Transaction transaction1 = new Transaction();
            transaction1.TransactionId = 1295;
            transaction1.Amount = 199.90;
            transaction1.CurrencyCode = "AAA";
            transaction1.TransactionDateTime = DateTime.Now;
            transaction1.Status = Common.Constants.Enum.TransactionStatus.Success;
            Transaction transaction2 = new Transaction();
            transaction2.TransactionId = 500;
            transaction2.Amount = 699.90;
            transaction2.CurrencyCode = "BBB";
            transaction2.TransactionDateTime = DateTime.Now.AddDays(-30);
            transaction2.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction3 = new Transaction();
            transaction3.TransactionId = 550;
            transaction3.Amount = 699.90;
            transaction3.CurrencyCode = "SEK";
            transaction3.TransactionDateTime = DateTime.Now.AddDays(-30);
            transaction3.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction4 = new Transaction();
            transaction4.TransactionId = 1;
            transaction4.Amount = 1.90;
            transaction4.CurrencyCode = "SEK";
            transaction4.TransactionDateTime = DateTime.Now.AddDays(1);
            transaction4.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction5 = new Transaction();
            transaction5.TransactionId = 2;
            transaction5.Amount = 1.90;
            transaction5.CurrencyCode = "SEK";
            transaction5.TransactionDateTime = DateTime.Now.AddDays(2);
            transaction5.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction6 = new Transaction();
            transaction6.TransactionId = 3;
            transaction6.Amount = 1.90;
            transaction6.CurrencyCode = "SEK";
            transaction6.TransactionDateTime = DateTime.Now.AddDays(3);
            transaction6.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction7 = new Transaction();
            transaction7.TransactionId = 4;
            transaction7.Amount = 1.90;
            transaction7.CurrencyCode = "SEK";
            transaction7.TransactionDateTime = DateTime.Now.AddDays(4);
            transaction7.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction8 = new Transaction();
            transaction8.TransactionId = 5;
            transaction8.Amount = 1.90;
            transaction8.CurrencyCode = "SEK";
            transaction8.TransactionDateTime = DateTime.Now.AddDays(5);
            transaction8.Status = Common.Constants.Enum.TransactionStatus.Failed;
            Transaction transaction9 = new Transaction();
            transaction9.TransactionId = 6;
            transaction9.Amount = 99999.90;
            transaction9.CurrencyCode = "SEK";
            transaction9.TransactionDateTime = DateTime.Now.AddDays(6);
            transaction9.Status = Common.Constants.Enum.TransactionStatus.Failed;

            return new List<Transaction>
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4,
                transaction5,
                transaction6,
                transaction7,
                transaction8,
                transaction9
            };
        }
    }
}