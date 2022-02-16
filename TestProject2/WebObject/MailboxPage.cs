using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.WebObject
{
    public class MailboxPage : BasePage
    {
        private readonly static By _mailboxLbl = By.XPath("//div[text()='Поиск по отправителю']");

        private readonly BaseElement _writeEmailButton = new BaseElement(By.XPath
            ("//span[@class = 'rui-Button-content']"));
        private readonly BaseElement _draftList = new BaseElement(By.XPath("//div[@class='FoldersItem-root-3P']//span[text() = 'Черновики']"));
        private readonly BaseElement _sentPage = new BaseElement(By.XPath("//div[@class='FoldersItem-root-3P']//span[text() = 'Отправленные']"));

        public MailboxPage() : base(_mailboxLbl, "Mailbox Page"){}

        public void WriteAnEmail()
        {
            _writeEmailButton.Click();
        }

        public void CheckReceived(string subject)
        {
            BaseElement messageSubject = new BaseElement(By.XPath("//span[@class = 'ListItem-subject-2M'][text() = '" + subject + "']"));
            messageSubject.WaitForIsVisible();
            Assert.IsTrue(messageSubject.Displayed);
        }

        public void GoToDraughtList()
        {
            _draftList.Click();
        }

        public void GoToSentPage()
        {
            _sentPage.Click();
        }
    }
}
