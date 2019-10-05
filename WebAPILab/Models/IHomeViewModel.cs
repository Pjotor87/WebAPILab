using System.Collections.Generic;
using Models;

namespace WebAPILab.Models
{
    public interface IHomeViewModel
    {
        IList<Customer> Customers { get; set; }
        IList<Transaction> Transactions { get; set; }
    }
}