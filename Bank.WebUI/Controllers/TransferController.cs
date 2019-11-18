using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.WebUI.Models;
using Bank.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebUI.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository repo;

        public TransferController(BankRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel model)
        {
            var sender = repo.Accounts.SingleOrDefault(x => x.AccountId == model.SenderAccountID);
            var recipient = repo.Accounts.SingleOrDefault(x => x.AccountId == model.RecipientAccountID);

            if(sender != null && recipient != null)
            {
                try
                {
                    repo.Transfer(sender, recipient, model.Amount);
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return View();
                }
                
            }

            TempData["Success"] = $"Transfer completed sucessfully. Sender balance is now: {sender.Balance}. Recipient balance is now {recipient.Balance}";
            return RedirectToAction("Transfer");
        }
    }
}