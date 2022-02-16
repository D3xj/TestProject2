using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Entities;
using TestProject2.WebObject;
using TestProject2.CSV_Tools;

namespace TestProject2.Tests
{
    [DeploymentItem(@"Resources")]
    [TestClass]
    public class CheckAnIncomingMessageTest : BaseTest
    {
        private SignInPage _signInPage;
        private MailboxPage _mailboxPage;
        private DraughtPage _daughtPage;
        private SentPage _sentPage;

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\CheckIncoming.csv", "CheckIncoming#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void CheckAnIncomingMessage()
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
            var toWhom = TestContext.DataRow["toWhom"].ToString();
            var subject = TestContext.DataRow["Subject"].ToString();
            var message = TestContext.DataRow["Message"].ToString();
            var num = Int32.Parse(TestContext.DataRow["Number"].ToString());
            _daughtPage.InputDataWithNum(toWhom, subject, message, num);
            _daughtPage.SendAMessage();
            _daughtPage.GoToMailboxPage();
            _mailboxPage = new MailboxPage();
            _mailboxPage.CheckReceived(subject + num);
            _mailboxPage.GoToSentPage();
            _sentPage = new SentPage();
            _sentPage.CheckSent(subject + num);
            _sentPage.Logout();
            num++;
            CSVWriter writer = new CSVWriter();
            writer.CsvWriter(toWhom, subject, message, num);
        }
    }

    

    
}
