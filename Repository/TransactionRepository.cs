using System.Collections.Generic;
using Angular.Asp.Net.Core.XSRF.RC2.Models;

namespace Angular.Asp.Net.Core.XSRF.RC2.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        static readonly List<Transaction> Transactions = new List<Transaction>();
        static readonly Account Account = new Account() { AccountNumber = "1234", CurrentBalance = 1000};

        public IEnumerable<Transaction> GetTransactions()
        {
            return Transactions;
        }

        public void AddTransaction(Transaction transaction)
        {

            if (transaction.TransactionType.Equals("DEBIT"))
            {
                Account.CurrentBalance = Account.CurrentBalance - transaction.TransactionAmount;
                transaction.Account = new Account { AccountNumber= Account.AccountNumber, CurrentBalance = Account.CurrentBalance};

            }
            else
            {
                Account.CurrentBalance = Account.CurrentBalance + transaction.TransactionAmount;
                transaction.Account = new Account { AccountNumber = Account.AccountNumber, CurrentBalance = Account.CurrentBalance };
            }

            Transactions.Add(transaction);
        }
    }
}
