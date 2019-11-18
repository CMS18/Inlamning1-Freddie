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

        public void Withdraw(Account account, decimal withdraw)
        {
            if (account.Balance >= withdraw && withdraw > 0)
            {
                account.Balance -= withdraw;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Deposit(Account account, decimal deposit)
        {
            if (0 < deposit)
            {
                account.Balance += deposit;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Transfer(Account sender, Account reciever, decimal amount)
        {
            if(amount > 0M)
            {
                if(amount <= sender.Balance)
                {
                    sender.Balance -= amount;
                    reciever.Balance += amount;
                } 
                else
                {
                    throw new TransferNotAllowedException("Amount exceeds senders current balance");
                }
            } 
            else
            {
                throw new TransferNotAllowedException("Amount cannot be negative or zero");
            }
        }
    }
}