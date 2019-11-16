using Bank.WebUI.Models;
using System;
using Xunit;

namespace Bank.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Withdraw()
        {
            //Arrange
            var account = new Account { Balance = 1000m, AccountId = 1 };
            var withdraw = 200m;
            var repo = new BankRepository();
            var expected = 800m;

            //Act
            repo.Withdraw(account, withdraw);

            //Assert
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void Deposit()
        {
            //Arrange
            var account = new Account { Balance = 2000.25m, AccountId = 10 };
            var deposit = 300.25m;
            var repo = new BankRepository();
            var expected = 2300.5m;

            //Act
            repo.Deposit(account, deposit);

            //Assert
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void NotAbleToWithdrawMoreThanCurrentBalance()
        {
            //Arrange
            var account = new Account { Balance = 2000.25m, AccountId = 3 };
            var withdraw = 2800m;
            var repo = new BankRepository();

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repo.Withdraw(account, withdraw));
        }
    }
}