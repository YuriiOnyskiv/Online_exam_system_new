
using Moq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Web;

namespace Tests
{


    public class AccountService
    {
        public bool DoLogin(string userEmail, string password)
        {
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password))
                return false;

            return true;
        }
        public string EmptyData(string userEmail, string password)
        {
           
                userEmail = string.Empty;
                password = string.Empty; 
            return "";
        }
        public bool DoRegister(string userName, string userLastName,int Age, string userEmail, string userPassword)
        {
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(userLastName) && string.IsNullOrEmpty(userEmail) &&
                string.IsNullOrEmpty(userPassword))
                return false;
            else
            {
                return true;
            }
        }
        public bool Age(int Age)
        {
           int _Age = Age;
            if (_Age <= 5)
            {
                return false;
            }
            else
                return true;
        }

        [Test]
        public void User_With_Correct_UserEmail_And_Password_Should_Login_Successfully()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.DoLogin("test@mail.com", "test123");

            // Assert
            Assert.IsTrue(result);            
           
        }

        [Test]
        public void User_With_Empty_UserEmail_And_Empty_Password()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            var result = accountService.EmptyData(string.Empty, string.Empty);

            // Assert
            Assert.IsEmpty(result);

        }
        
        [Test]

        public void Registration_User_With_Correct_Data()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.DoRegister("Romek", "Sparrow", 28, "Romek.1989@mail.com", "pass123" );

            // Assert
            Assert.IsTrue(result);          

        }
        [Test]

        public void Age_Validation()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.Age(6);

            // Assert
            Assert.IsTrue(result);
            
        }


    }
}