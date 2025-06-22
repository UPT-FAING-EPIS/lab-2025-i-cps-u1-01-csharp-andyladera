using Bank.Domain.Models;

namespace Bank.Domain.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Credit(creditAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        // NUEVAS PRUEBAS PARA INCREMENTAR COBERTURA:

        [TestMethod]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -4.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        [TestMethod]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -4.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 15.00; // Mayor que el balance
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
    }
}