using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject2.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService(@"C:\Users\pc\Desktop\TestProject2\TestProject2\bin\Debug\net6.0");
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--disable-notifications");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
            }
            return driver;
        }
    }
}
