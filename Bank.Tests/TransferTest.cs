using Bank.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bank.Tests
{
    public class TransferTest
    {
        [Fact]
        public void TransferCorrect()
        {
            // Arrange
            var repo = new BankRepository();
            var sender = new Account { AccountId = 1, Balance = 1000M };
            var recipient = new Account { AccountId = 2, Balance = 0M };

            var expectedSenderAmount = 500M;
            var expectedRecipientAmount = 500M;

            // Act
            repo.Transfer(sender, recipient, 500M);

            // Assert
            Assert.Equal(expectedSenderAmount, sender.Balance);
            Assert.Equal(expectedRecipientAmount, recipient.Balance);
        }
    }
}
