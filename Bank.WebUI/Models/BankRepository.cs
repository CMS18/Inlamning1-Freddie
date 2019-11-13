using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.WebUI.Models
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public BankRepository()
        {
            Customers.Add(new Customer { CustomerId = 1, Name = "Johan" });
            Customers.Add(new Customer { CustomerId = 2, Name = "Anna" });
            Customers.Add(new Customer { CustomerId = 3, Name = "Filip" });

            Accounts.Add(new Account { CustomerId = 1, AccountId = 643262, Balance = 9000m });
            Accounts.Add(new Account { CustomerId = 1, AccountId = 954623, Balance = 4500m });
            Accounts.Add(new Account { CustomerId = 2, AccountId = 7134, Balance = 10000m });
            Accounts.Add(new Account { CustomerId = 3, AccountId = 2537, Balance = 5000m });
        }
    }
}