using System.Collections.Generic;
using Common.Models;

namespace DAL.Seed
{
    public interface ITransactionSeed
    {
        List<ITransaction> GetSeed();
    }
}