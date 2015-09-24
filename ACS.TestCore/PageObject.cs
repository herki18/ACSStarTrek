using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace ACS.TestCore
{
    public abstract class PageObject : IDisposable
    {
        private string _extensionLocation = "extension.crx";
        private bool _isLocal = true;

        protected IWebDriver WebDriver { get; set; }

        public string ExtensionLocation
        {
            get { return _extensionLocation; }
            set { _extensionLocation = value; }
        }

        public bool IsLocal
        {
            get { return _isLocal; }
            set { _isLocal = value; }
        }

        protected PageObject()
        {
            IsLocal = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLocal"]);
            ExtensionLocation = ConfigurationManager.AppSettings["ExtensionLocation"];

            Start();
        }

        protected void Start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExtension(ExtensionLocation);

            if (_isLocal)
            {
                WebDriver = new ChromeDriver(options);
            }
            else
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability(ChromeOptions.Capability, options);
                WebDriver = new RemoteWebDriver(new Uri(""), DesiredCapabilities.Chrome());
            }
            
        }

        protected void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        protected void Close()
        {
            WebDriver.Close();
        }

        public void Dispose()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
                WebDriver.Dispose();
            }
        }
    }
}
