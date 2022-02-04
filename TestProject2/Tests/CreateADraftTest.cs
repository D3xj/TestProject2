using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.WebObject;

namespace TestProject2.Tests
{
    [TestClass]
    public class CreateADraftTest : BaseTest
    {
        private SignInPage _signInPage;
        private MailboxPage _mailboxPage;
        private DraughtPage _daughtPage;

        private const string toWhom = "ishhf31@rambler.ru";
        private const string subject = "Test subject";
        private const string message = "Test message";

        [TestMethod]
        public void CreateADraft()
        {
            _signInPage = new SignInPage();
            _signInPage.EnterYourDataToFields(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"]);
            _signInPage.Submit();
            _mailboxPage = new MailboxPage();
            _mailboxPage.WriteAnEmail();
            _daughtPage = new DraughtPage();
            _daughtPage.InputData(toWhom, subject, message);
            _daughtPage.SaveDraught();
            _daughtPage.Logout();
        }
    }
}
