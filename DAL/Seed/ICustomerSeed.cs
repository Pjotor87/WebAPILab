using System.Collections.Generic;
using Common.Models;

namespace DAL.Seed
{
    public interface ICustomerSeed
    {
        List<ICustomer> GetSeed();
    }
}