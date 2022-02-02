using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestProject2.WebDriver
{
    public class Configuration
    {
        public static string GetEnvironmentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");
        public static string Browser => GetEnvironmentVar("Browser", "Chrome");
        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://mail.rambler.ru/?utm_source=head&utm_campaign=self_promo&utm_medium=header&utm_content=mail");

    }
}
