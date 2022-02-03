using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.WebObject
{
    public class DraughtListPage : BasePage
    {
        private readonly static By _draughtListLbl = By.XPath("//span[@class = 'rui-Button-content']");

        private readonly BaseElement _toBeDeletedMessage = new BaseElement(By.XPath("//span[@class='Checkbox-root-vD']"));
        private readonly BaseElement _toDelete = new BaseElement(By.XPath("//span[@class = 'ButtonWithIcon-icon-1Q ButtonWithIcon-iconLeft-2c ButtonWithIcon-iconBig-2w']"));
        private readonly BaseElement _profileButton = new BaseElement(By.XPath("//button[@class = 'rui__2FTrL']"));
        private readonly BaseElement _logoutButton = new BaseElement(By.XPath("//button[@class='rui__1iR9f']"));

        public DraughtListPage() : base(_draughtListLbl, "Draft List Page"){}

        public void SelectMessage()
        {
            _toBeDeletedMessage.Click();
        }

        public void DeleteMessage()
        {
            _toDelete.Click();
        }

        public void Logout()
        {
            _profileButton.Click();
            _logoutButton.Click();
        }
    }
}
