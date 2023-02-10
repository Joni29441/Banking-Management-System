using BankSystem.Controllers;
using BankSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bank.UnitTest
{
    [TestClass]
    public class LoginTests
    {
        private login _login;

        [TestInitialize]
        public void Initialize()
        {
            _login = new login();
        }

        [TestMethod]
        public void TestNameIsRequired()
        {
            _login.Name = "";
            var validationResults = ValidateModel(_login);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains("Name")));
        }

        [TestMethod]
        public void TestNameLength()
        {
            _login.Name = "Ab";
            var validationResults = ValidateModel(_login);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains("Name")));

            _login.Name = new string('a', 21);
            validationResults = ValidateModel(_login);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains("Name")));
        }

        [TestMethod]
        public void TestEmailIsValid()
        {
            _login.Email = "invalidemail";
            var validationResults = ValidateModel(_login);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains("Email")));
        }

        private IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

    }

    
        [TestClass]
        public class TransferTests
        {
            [TestMethod]
            public void TestTransferProperties()
            {
                // Arrange
                var transfer = new transfer();
                string expectedAccountNumber = "1234567890";
                string expectedCUSIP = "ABC123";
                string expectedAccountHolder = "John Doe";
                float expectedAmount = 100.0f;

                // Act
                transfer.AccountNumber = expectedAccountNumber;
                transfer.CUSIP = expectedCUSIP;
                transfer.AccountHolder = expectedAccountHolder;
                transfer.Amount = expectedAmount;

                // Assert
                Assert.AreEqual(expectedAccountNumber, transfer.AccountNumber);
                Assert.AreEqual(expectedCUSIP, transfer.CUSIP);
                Assert.AreEqual(expectedAccountHolder, transfer.AccountHolder);
                Assert.AreEqual(expectedAmount, transfer.Amount);
            }
        }
}
    
