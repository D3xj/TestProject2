using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
    public class DeleteADraftTest : BaseTest
    {
        private SignInPage _signInPage;
        private MailboxPage _mailboxPage;
        private DraughtListPage _daughtListPage;

        [TestMethod]
        public void DeleteADraft()
        {
            _signInPage = new SignInPage();
            var email = ConfigurationManager.AppSettings["email"];
            var password = ConfigurationManager.AppSettings["password"];
            var user = new User(email, password);
            _signInPage.EnterYourDataToFields(user);
            _signInPage.Submit();
            _mailboxPage = new MailboxPage();
            _mailboxPage.GoToDraughtList();
            _daughtListPage = new DraughtListPage();
            _daughtListPage.SelectMessage();
            _daughtListPage.DeleteMessage();
            _daughtListPage.Logout();
        }
    }
}
