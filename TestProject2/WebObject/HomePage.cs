using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.WebObject
{
    public class HomePage : BasePage
    {
        private static readonly By _homeLbl = By.XPath("//a[@href = 'https://mail.rambler.ru/?utm_source=head&utm_campaign=self_promo&utm_medium=header&utm_content=mail']");

        private readonly BaseElement _linkSignIn = new BaseElement(By.XPath("//a[@href = 'https://mail.rambler.ru/?utm_source=head&utm_campaign=self_promo&utm_medium=header&utm_content=mail']"));

        public HomePage() : base(_homeLbl, "Home Page"){}

        public void GoToSignIn()
        {
            _linkSignIn.Click(); 
        }
    }
}
