using System.Net.Http;
using ACS.TestCore;
using Microsoft.Owin.Hosting;

namespace ACS.StartTrekTesting.CrewManifestsTest
{
    public class CrewManifestsPageObject : PageObject
    {
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
