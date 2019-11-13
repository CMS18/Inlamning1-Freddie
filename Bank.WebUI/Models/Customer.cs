using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.WebUI.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
    }
}