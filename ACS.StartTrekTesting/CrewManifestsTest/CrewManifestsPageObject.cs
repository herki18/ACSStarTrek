using System.Net.Http;
using ACS.TestCore;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ACS.StartTrekTesting.CrewManifestsTest
{
    public class CrewManifestsPageObject : PageObject
    {
        [Before]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {
            Dispose();
        }

        [AfterStep()]
        public void AfterStep()
        {
            Engine.CollectLogsFromBrowser();
        }

        string baseAddress = "http://localhost:64828/";

        public CrewManifestsPageObject()
        {
            WebApp.Start<CrewManifestsStartup>(url: baseAddress);
            //HttpClient client = new HttpClient();
            
            // Initialize Selenium
            Initialize();
        } 
    }
}
