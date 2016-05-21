using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Asp.Net.Core.XSRF.RC2.Models;

namespace Angular.Asp.Net.Core.XSRF.RC2.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        static readonly List<Transaction> _transactions = new List<Transaction>();
        static readonly Account _account = new Account() { AccountNumber = "1234", CurrentBalance = 1000};

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public void AddTransaction(Transaction transaction)
        {
            if (_account.AccountNumber == transaction.Account.AccountNumber)
            {
                if (transaction.TransactionType.Equals("DEBIT"))
                {
                    _account.CurrentBalance = _account.CurrentBalance - transaction.TransactionAmount;

                }
                else
                {
                    _account.CurrentBalance = _account.CurrentBalance + transaction.TransactionAmount;
                }

                _transactions.Add(transaction);
            }
        }
    }
}
