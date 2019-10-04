using System;
using System.Collections.Generic;
using Common.Models;

namespace DAL.Seed
{
    public class TransactionSeed : ISeed<Transaction>
    {
        public List<Transaction> GetSeed()
        {
            return new List<Transaction>
            {
                new Transaction()
                {
                    TransactionId = 1295,
                    Amount = 199.90,
                    CurrencyCode = "AAA",
                    TransactionDateTime = DateTime.Now,
                    Status = Common.Constants.Enum.TransactionStatus.Success
                },
                new Transaction()
                {
                    TransactionId = 500,
                    Amount = 699.90,
                    CurrencyCode = "BBB",
                    TransactionDateTime = DateTime.Now.AddDays(-30),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 550,
                    Amount = 699.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(-30),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 1,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(1),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 2,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(2),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 3,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(3),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 4,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(4),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 5,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(5),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 6,
                    Amount = 99999.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(6),
                    Status = Common.Constants.Enum.TransactionStatus.Failed
                }
            };
        }
    }
}