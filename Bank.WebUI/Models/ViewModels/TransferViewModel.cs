using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.WebUI.Models.ViewModels
{
    public class TransferViewModel
    {
        public int SenderAccountID { get; set; }
        public int RecipientAccountID { get; set; }
        public decimal Amount { get; set; }
    }
}
