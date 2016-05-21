using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Asp.Net.Core.XSRF.RC2.Models;

namespace Angular.Asp.Net.Core.XSRF.RC2.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        void AddTransaction(Transaction transaction);
    }
}
