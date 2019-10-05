using System.Collections.Generic;
using Models;

namespace DAL.Seed
{
    public interface ITransactionSeed
    {
        List<Transaction> GetSeed();
    }
}