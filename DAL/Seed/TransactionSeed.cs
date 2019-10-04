using System;
using System.Collections.Generic;
using Common.Models;

namespace DAL.Seed
{
    public class TransactionSeed : ITransactionSeed
    {
        public List<ITransaction> GetSeed()
        {
            ITransaction transaction1 = ModelFactory.CreateTransaction();
            transaction1.TransactionId = 1295;
            transaction1.Amount = 199.90;
            transaction1.CurrencyCode = "AAA";
            transaction1.TransactionDateTime = DateTime.Now;
            transaction1.Status = Common.Constants.Enum.TransactionStatus.Success;
            ITransaction transaction2 = ModelFactory.CreateTransaction();
            transaction2.TransactionId = 500;
            transaction2.Amount = 699.90;
            transaction2.CurrencyCode = "BBB";
            transaction2.TransactionDateTime = DateTime.Now.AddDays(-30);
            transaction2.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction3 = ModelFactory.CreateTransaction();
            transaction3.TransactionId = 550;
            transaction3.Amount = 699.90;
            transaction3.CurrencyCode = "SEK";
            transaction3.TransactionDateTime = DateTime.Now.AddDays(-30);
            transaction3.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction4 = ModelFactory.CreateTransaction();
            transaction4.TransactionId = 1;
            transaction4.Amount = 1.90;
            transaction4.CurrencyCode = "SEK";
            transaction4.TransactionDateTime = DateTime.Now.AddDays(1);
            transaction4.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction5 = ModelFactory.CreateTransaction();
            transaction5.TransactionId = 2;
            transaction5.Amount = 1.90;
            transaction5.CurrencyCode = "SEK";
            transaction5.TransactionDateTime = DateTime.Now.AddDays(2);
            transaction5.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction6 = ModelFactory.CreateTransaction();
            transaction6.TransactionId = 3;
            transaction6.Amount = 1.90;
            transaction6.CurrencyCode = "SEK";
            transaction6.TransactionDateTime = DateTime.Now.AddDays(3);
            transaction6.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction7 = ModelFactory.CreateTransaction();
            transaction7.TransactionId = 4;
            transaction7.Amount = 1.90;
            transaction7.CurrencyCode = "SEK";
            transaction7.TransactionDateTime = DateTime.Now.AddDays(4);
            transaction7.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction8 = ModelFactory.CreateTransaction();
            transaction8.TransactionId = 5;
            transaction8.Amount = 1.90;
            transaction8.CurrencyCode = "SEK";
            transaction8.TransactionDateTime = DateTime.Now.AddDays(5);
            transaction8.Status = Common.Constants.Enum.TransactionStatus.Failed;
            ITransaction transaction9 = ModelFactory.CreateTransaction();
            transaction9.TransactionId = 6;
            transaction9.Amount = 99999.90;
            transaction9.CurrencyCode = "SEK";
            transaction9.TransactionDateTime = DateTime.Now.AddDays(6);
            transaction9.Status = Common.Constants.Enum.TransactionStatus.Failed;

            return new List<ITransaction>
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