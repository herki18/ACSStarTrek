using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Protractor;

namespace ACS.TestCore
{
    public class TFDriver
    {
        #region Engine

        private string _extensionLocation = "extension.crx";
        private bool _isLocal = true;

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

        
        private IWebDriver WebDriver { get; set; }
        private IJavaScriptExecutor JavaScriptExecutor { get; set; }
        public NgWebDriver NgWebDriver { get; private set; }

        public TFDriver()
        {
            Start();
        }

        protected void Start()
        {
            LoadConfiguration();

            ChromeOptions options = new ChromeOptions();
            options.AddExtension(ExtensionLocation);

            if (_isLocal)
            {
               WebDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(120));
               WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            }
            else
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability(ChromeOptions.Capability, options);
                WebDriver = new RemoteWebDriver(new Uri(""), DesiredCapabilities.Chrome(), TimeSpan.FromSeconds(120));
                WebDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            }

            NgWebDriver = new NgWebDriver(WebDriver);
        }

        private void LoadConfiguration()
        {
            IsLocal = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLocal"]);
            ExtensionLocation = ConfigurationManager.AppSettings["ExtensionLocation"];
        }

        public void CollectLogsFromBrowser()
        {
            JavaScriptExecutor = WebDriver as IJavaScriptExecutor;

            if (JavaScriptExecutor != null)
            {
                var errors = JavaScriptExecutor.ExecuteScript(@"return window.JSLogCollector ?  window.JSLogCollector.pump() : [];");

                var collection = errors as ReadOnlyCollection<object>;
                foreach (var item in collection)
                {
                    var errorObject = item as Dictionary<string, object>;
                    foreach (var field in errorObject)
                    {
                        if (field.Value.GetType() == typeof (Dictionary<string,object>))
                        {
                            var innerItem = field.Value as Dictionary<string, object>;
                            foreach (var inner in innerItem)
                            {
                                Console.WriteLine(inner.Key + " - " + inner.Value);
                            }
                        }
                        else
                        {
                            Console.WriteLine(field.Key + " - " + field.Value);
                        }
                    }
                    Console.WriteLine("-------------------");
                }
            }
        }

        

        protected void Close()
        {
            WebDriver.Close();
        }

        public void Dispose()
        {
            if (NgWebDriver != null)
            {
                NgWebDriver.Quit();
                NgWebDriver.Dispose();
            }

            if (WebDriver != null)
            {
                WebDriver.Quit();
                WebDriver.Dispose();
            }
        }

        #endregion

        #region WebDriver

        public void GoToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        #endregion

        #region anguler

        

        public string FindElementById(string id)
        {
            return NgWebDriver.FindElement(By.Id(id)).Text;
        }


        #endregion
    }
}
