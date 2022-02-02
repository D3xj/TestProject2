using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.WebObject;

namespace TestProject2.Tests
{
    [TestClass]
    public class DeleteADraftTest : BaseTest
    {
        private SignInPage _signInPage;
        private MailboxPage _mailboxPage;
        private DraughtListPage _daughtListPage;

        private const string email = "testaccount74@rambler.ru";
        private const string password = "testAccount74";

        [TestMethod]
        public void DeleteADraft()
        {
            _signInPage = new SignInPage();
            _signInPage.EnterYourDataToFields(email, password);
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
