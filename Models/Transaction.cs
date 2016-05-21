using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Asp.Net.Core.XSRF.RC2.Models
{
    public class Transaction
    {
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public Account Account { get; set; }
    }
}
