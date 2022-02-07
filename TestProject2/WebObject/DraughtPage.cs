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

        public DraughtPage() : base(_draughtLbl, "Draft Page"){}

        public void InputData(string toWhom, string subject, string email)
        {
            _toWhom.SendKeys(toWhom);
            _subject.SendKeys(subject);
            Browser.ObtainDriver().SwitchTo().Frame(_searchIFrame.GetElement());
            _textOfEmail.SendKeys(email);
            Browser.ObtainDriver().SwitchTo().DefaultContent();
        }

        public void SaveDraught()
        {
            _saveDraught.Click();
        }

        public void Logout()
        {
            _profileButton.Click();
            _logoutButton.Click();
        }
    }
}
