using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.WebDriver;

namespace TestProject2.WebObject
{
    public class SignInPage : BasePage
    {

        private static readonly By _signInLbl = By.XPath
            ("//iframe[@src = 'https://id.rambler.ru/login-20/login?utm_source=head&utm_campaign=self_promo&utm_medium=header&utm_content=mail&rname=mail&theme=&session=false&back=https%3A%2F%2Fmail.rambler.ru%2F%3Futm_source%3Dhead%26utm_campaign%3Dself_promo%26utm_medium%3Dheader%26utm_content%3Dmail&param=embed&iframeOrigin=https%3A%2F%2Fmail.rambler.ru']");

        private readonly BaseElement _searchIFrame = new BaseElement(By.XPath
            ("//iframe[@src = 'https://id.rambler.ru/login-20/login?utm_source=head&utm_campaign=self_promo&utm_medium=header&utm_content=mail&rname=mail&theme=&session=false&back=https%3A%2F%2Fmail.rambler.ru%2F%3Futm_source%3Dhead%26utm_campaign%3Dself_promo%26utm_medium%3Dheader%26utm_content%3Dmail&param=embed&iframeOrigin=https%3A%2F%2Fmail.rambler.ru']"));
        private readonly BaseElement _inputEmail = new BaseElement(By.XPath
            ("//input[@class = 'rui-Input-input -motrika-nokeys']"));
        private readonly BaseElement _inputPassword = new BaseElement(By.XPath
            ("//input[@class = 'rui-Input-input -metrika-nokeys']"));
        private readonly BaseElement _submitButton = new BaseElement(By.XPath
            ("//button[@class = 'rui-Button-button rui-Button-type-primary rui-Button-size-medium rui-Button-iconPosition-left rui-Button-block']"));

        public SignInPage() : base(_signInLbl, "Sign In page"){}

        public void EnterYourDataToFields(string email, string password)
        {
            Browser.ObtainDriver().SwitchTo().Frame(_searchIFrame.GetElement());
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);
        }

        public void Submit()
        {
            _submitButton.Click();
        }
    }
}
