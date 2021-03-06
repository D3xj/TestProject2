using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Entities;
using TestProject2.WebObject;

namespace TestProject2.Tests
{
    [DeploymentItem(@"Resources")]
    [TestClass]
    public class CreateADraftTest : BaseTest
    {
        private SignInPage _signInPage;
        private MailboxPage _mailboxPage;
        private DraughtPage _daughtPage;

        //private const string toWhom = "ishhf31@rambler.ru";
        //private const string subject = "Test subject";
        //private const string message = "Test message";
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateADraft()
        {
            _signInPage = new SignInPage();
            var email = ConfigurationManager.AppSettings["email"];
            var password = ConfigurationManager.AppSettings["password"];
            var user = new User(email, password);
            _signInPage.EnterYourDataToFields(user);
            _signInPage.Submit();
            _mailboxPage = new MailboxPage();
            _mailboxPage.WriteAnEmail();
            _daughtPage = new DraughtPage();

            var toWhom = TestContext.DataRow["Send"].ToString();
            var subject = TestContext.DataRow["Subject"].ToString();
            var message = TestContext.DataRow["Message"].ToString();

            _daughtPage.InputData(toWhom, subject, message);
            _daughtPage.SaveDraught();
            _daughtPage.Logout();
        }
    }
}
