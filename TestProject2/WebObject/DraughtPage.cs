using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.WebDriver;

namespace TestProject2.WebObject
{
    public class DraughtPage : BasePage
    {
        private readonly static By _draughtLbl = By.XPath("//p[@class = 'Compose-heading-FK']");

        private readonly BaseElement _toWhom = new BaseElement(By.XPath("//input[@id = 'receivers']"));
        private readonly BaseElement _subject = new BaseElement(By.XPath("//input[@id = 'subject']"));
        private readonly BaseElement _textOfEmail = new BaseElement(By.XPath("//body[@class = 'mce-content-body ']"));
        private readonly BaseElement _searchIFrame = new BaseElement(By.Id("editor_ifr"));
        private readonly BaseElement _saveDraught = new BaseElement(By.XPath("//span[text() = 'Сохранить черновик']"));
        private readonly BaseElement _profileButton = new BaseElement(By.XPath("//button[@class = 'rui__2FTrL']"));
        private readonly BaseElement _logoutButton = new BaseElement(By.XPath("//button[@class='rui__1iR9f']"));
        private readonly BaseElement _sendButton = new BaseElement(By.XPath("//button[@class='rui-Button-button rui-Button-type-primary rui-Button-size-small rui-Button-iconPosition-left']"));
        private readonly BaseElement _mailboxPage = new BaseElement(By.XPath("//div[@class = 'Sidebar-content-1p']//span[text()='Входящие']"));

        public DraughtPage() : base(_draughtLbl, "Draft Page"){}

        public void InputData(string toWhom, string subject, string email)
        {
            _toWhom.SendKeys(toWhom);
            _subject.SendKeys(subject);
            Browser.ObtainDriver().SwitchTo().Frame(_searchIFrame.GetElement());
            _textOfEmail.SendKeys(email);
            Browser.ObtainDriver().SwitchTo().DefaultContent();
        }
        public void InputDataWithNum(string toWhom, string subject, string email, int num)
        {
            _toWhom.SendKeys(toWhom);
            _subject.SendKeys(subject + num);
            Browser.ObtainDriver().SwitchTo().Frame(_searchIFrame.GetElement());
            _textOfEmail.SendKeys(email);
            Browser.ObtainDriver().SwitchTo().DefaultContent();
        }

        public void SaveDraught()
        {
            _saveDraught.Click();
        }

        public void SendAMessage()
        {
            _sendButton.Click();
        }

        public void GoToMailboxPage()
        {
            _mailboxPage.Click();
        }

        public void Logout()
        {
            _profileButton.Click();
            _logoutButton.Click();
        }
    }
}
