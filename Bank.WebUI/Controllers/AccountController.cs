using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankRepository _repo;

        public AccountController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(int accountID, decimal amount)
        {
            var account = _repo.Accounts.Where(c => c.AccountId == accountID).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Withdraw(account, amount);
                    TempData["info"] = "Current balance is: " + account.Balance;
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["info"] = "Insufficient funds, current balance is: " + account.Balance;
                }
            }
            else
            {
                TempData["info"] = "Account cannot be found";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deposit(int accountID, decimal amount)
        {
            var account = _repo.Accounts.Where(c => c.AccountId == accountID).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Deposit(account, amount);
                    TempData["info"] = "Current balance is: " + account.Balance;
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["info"] = "The deposit must be greater than zero.";
                }
            }
            else
            {
                TempData["info"] = "Account cannot be found";
            }
            return RedirectToAction("Index");
        }
    }
}