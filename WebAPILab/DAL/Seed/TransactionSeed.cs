using System;
using System.Collections.Generic;
using WebAPILab.Models;

namespace WebAPILab.DAL.Seed
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
                    Status = Constants.Enum.TransactionStatus.Success
                },
                new Transaction()
                {
                    TransactionId = 500,
                    Amount = 699.90,
                    CurrencyCode = "BBB",
                    TransactionDateTime = DateTime.Now.AddDays(-30),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 550,
                    Amount = 699.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(-30),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 1,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(1),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 2,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(2),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 3,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(3),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 4,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(4),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 5,
                    Amount = 1.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(5),
                    Status = Constants.Enum.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 6,
                    Amount = 99999.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(6),
                    Status = Constants.Enum.TransactionStatus.Failed
                }
            };
        }
    }
}