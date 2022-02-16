using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.WebObject
{
    public class SentPage : BasePage
    {
        private readonly static By _sentLbl = By.XPath("//div[text()='Поиск по получателю']");
        
        private readonly BaseElement _profileButton = new BaseElement(By.XPath("//button[@class = 'rui__2FTrL']"));
        private readonly BaseElement _logoutButton = new BaseElement(By.XPath("//button[@class='rui__1iR9f']"));

        public SentPage() : base(_sentLbl, "Sent Messages Page"){}

        public void CheckSent(string subject)
        {
            BaseElement messageSubject = new BaseElement(By.XPath("//span[@class = 'ListItem-subject-2M'][text() = '" + subject + "']"));
            messageSubject.WaitForIsVisible();
            Assert.IsTrue(messageSubject.Displayed);
        }

        public void Logout()
        {
            _profileButton.Click();
            _logoutButton.Click();
        }
    }
}
