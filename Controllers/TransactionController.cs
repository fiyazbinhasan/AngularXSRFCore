using System.Collections.Generic;
using Angular.Asp.Net.Core.XSRF.RC2.Models;
using Angular.Asp.Net.Core.XSRF.RC2.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular.Asp.Net.Core.XSRF.RC2.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        public ITransactionRepository Repository;

        public TransactionController(ITransactionRepository repository)
        {
            Repository = repository;
        }
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return Repository.GetTransactions();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Post([FromBody]Transaction transaction)
        {
            Repository.AddTransaction(transaction);
        }
    }
}
