using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace ACS.StartTrekTesting
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Testing()
        {
            //var options = new ChromeOptions();
            //options.AddExtension("extension.crx");
            var optn = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();
            service.LogPath = "chromedriver.log";
            service.EnableVerboseLogging = true;
            optn.AddExtension("extension.crx");
            var driver = new ChromeDriver(service, optn);
            //var driver = new ChromeDriver(options);
            

            driver.Navigate().GoToUrl("http://localhost:64834/");

            
            var javascriptDriver = (IJavaScriptExecutor) driver;
            var errors = javascriptDriver.ExecuteScript("return window.JSErrorCollector_errors ? window.JSErrorCollector_errors.pump() : [];");
            
            //var writer = new StreamWriter("jsErrors.log");
            var collection = errors as ReadOnlyCollection<object>;
            foreach (var item in collection)
            {
                var errorObject = item as Dictionary<string, object>;
                foreach (var field in errorObject)
                {
                    Console.WriteLine(field.Key + " - " + field.Value);
                }
                Console.WriteLine("-------------------");
            }
            //writer.Flush();
            //writer.Close();

            driver.Close();
            driver.Quit();
        }
    }
}
