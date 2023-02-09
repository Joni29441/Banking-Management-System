using Xunit;

namespace BankSystem.Tests
{
    public class LoginTests
    {
        [Fact]
        public void TestNameIsRequired()
        {
            var login = new login();
            Assert.Throws<ValidationException>(() =>
            Validator.ValidateObject(login, new ValidationContext(login), true));
        }
        [Fact]
        public void TestUsernameIsRequired()
        {
            var login = new login();
            login.Name = "John Doe";
            Assert.Throws<ValidationException>(() =>
                Validator.ValidateObject(login, new ValidationContext(login), true));
        }

        [Fact]
        public void TestPasswordIsRequired()
        {
            var login = new login();
            login.Name = "John Doe";
            login.Username = "johndoe";
            Assert.Throws<ValidationException>(() =>
                Validator.ValidateObject(login, new ValidationContext(login), true));
        }

        [Fact]
        public void TestDOBIsRequired()
        {
            var login = new login();
            login.Name = "John Doe";
            login.Username = "johndoe";
            login.Password = "password";
            Assert.Throws<ValidationException>(() =>
                Validator.ValidateObject(login, new ValidationContext(login), true));
        }

        [Fact]
        public void TestPhoneIsRequired()
        {
            var login = new login();
            login.Name = "John Doe";
            login.Username = "johndoe";
            login.Password = "password";
            login.DOB = new DateTime(2000, 1, 1);
            Assert.Throws<ValidationException>(() =>
                Validator.ValidateObject(login, new ValidationContext(login), true));
        }

        [Fact]
        public void TestEmailIsRequired()
        {
            var login = new login();
            login.Name = "John Doe";
            login.Username = "johndoe";
            login.Password = "password";
            login.DOB = new DateTime(2000, 1, 1);
            login.Phone = "1234567890";
            Assert.Throws<ValidationException>(() =>
                Validator.ValidateObject(login, new ValidationContext(login), true));
        }
    }
 }
