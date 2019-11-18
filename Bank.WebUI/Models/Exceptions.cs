using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.WebUI.Models
{
    public class TransferNotAllowedException : Exception
    {
        public TransferNotAllowedException()
        {
        }

        public TransferNotAllowedException(string message) : base(message)
        {
        }
    }
}
