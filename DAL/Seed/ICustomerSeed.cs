using System.Collections.Generic;
using Models;

namespace DAL.Seed
{
    public interface ICustomerSeed
    {
        List<Customer> GetSeed();
    }
}