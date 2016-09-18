using System.Collections.Generic;
using Angular.Asp.Net.Core.XSRF.RC2.Models;

namespace Angular.Asp.Net.Core.XSRF.RC2.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        void AddTransaction(Transaction transaction);
    }
}
