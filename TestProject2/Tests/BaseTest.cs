using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.WebDriver;

namespace TestProject2.Tests
{
    public class BaseTest
    {
        protected static Browser browser;

        [TestInitialize]
        public void SetupTest()
        {
            browser = Browser.Instance;
            Browser.WindowsMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
