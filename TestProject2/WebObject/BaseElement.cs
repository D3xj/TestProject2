using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject2.WebDriver;

namespace TestProject2.WebObject
{
    public class BaseElement : IWebElement
    {
        private IWebDriver _driver = Browser.ObtainDriver();
        protected string _name;
        protected By _locator;
        protected IWebElement _element;

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return _element.Text;
        }

        public IWebElement GetElement()
        {
            WaitForIsVisible();
            try
            {
                _element = Browser.ObtainDriver().FindElement(_locator);
            }
            catch (Exception)
            {
                throw;
            }
            return _element;
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(_locator);
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public IWebElement FindElement(By @by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.ObtainDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.ObtainDriver().FindElement(_locator).Click();
        }

        public void JSClick()
        {
            this.WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.ObtainDriver();
            executor.ExecuteScript("arguments[0].click();", this.GetElement());
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }
        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed { get; }  

    }
}
