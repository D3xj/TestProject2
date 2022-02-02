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
        private readonly static By _mailboxLbl = By.XPath("//span[@class = 'rui-Button-content']"); //Исправить

        private readonly BaseElement _writeEmailButton = new BaseElement(By.XPath
            ("//span[@class = 'rui-Button-content']"));
        private readonly BaseElement _draftList = new BaseElement(By.XPath("//span[text() = 'Черновики']"));

        public MailboxPage() : base(_mailboxLbl, "Mailbox Page"){}

        public void WriteAnEmail()
        {
            _writeEmailButton.Click();
        }

        public void GoToDraughtList()
        {
            _draftList.Click();
        }
    }
}
