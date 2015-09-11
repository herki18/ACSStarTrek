using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACS.StartTrekTesting
{
    [TestFixture]
    public class CrewManifestTest
    {
        private ChromeDriver _driver;

        [SetUp]
        public void SetUp()
        {
            var optn = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();
            service.LogPath = "chromedriver.log";
            service.EnableVerboseLogging = true;
            optn.AddExtension("extension.crx");
            
            _driver = new ChromeDriver(service, optn);
        }


        [Test]
        public void Navigation_GoDoCrewManifestPage_ShowCrewManifestPage()
        {
            //InjectLogger(_driver);
            //InjectLogger(_driver);
            _driver.Navigate().GoToUrl("localhost:64834");
            
            //GetLoggs(_driver);    
            CollectLogsFromBrowser(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        private void GetLoggs(IJavaScriptExecutor driver)
        {
            //var logs = driver.ExecuteScript(@"return window.JSLogCollector ?  window.JSLogCollector.pump() : [];");
            var logs = driver.ExecuteScript(@"return window.JSLogCollector.pump();");
        }

        private void InjectLogger(IJavaScriptExecutor driver)
        {
            driver.ExecuteScript(@" sessionStorage.loggs = [];
                                    var oldf = console.log; 
		                            console.log = function()
		                            { 
			                            sessionStorage.loggs.push(arguments); 
			                            oldf.apply(console, arguments); 
		                            };");
        }

        private void CollectLogsFromBrowser(IJavaScriptExecutor driver)
        {
            var errors = driver.ExecuteScript(@"return window.JSLogCollector ?  window.JSLogCollector.pump() : [];");
            
            //var errors = driver.ExecuteScript("return window.JSErrorCollector_errors ? window.JSErrorCollector_errors.pump() : [];");

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
        }
    }
}
