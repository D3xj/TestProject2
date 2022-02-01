using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestProject2.WebObject
{
    public class BasePage
    {
        protected By _titleLocator;
        protected string _title;
        public static string _titleForm;

        protected BasePage(By TitleLocatior, string title)
        {
            _titleLocator = TitleLocatior;
            _title = _titleForm = title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(_titleLocator, _title);
            label.WaitForIsVisible();
        }
    }
}
