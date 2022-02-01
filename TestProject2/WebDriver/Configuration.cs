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
        public static string StartUrl => GetEnvironmentVar("StartUrl", "");

    }
}
