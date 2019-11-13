using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.WebUI.Models
{
    public class Account
    {
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
    }
}