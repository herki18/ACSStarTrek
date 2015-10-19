using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ACS.TestCore;
using Microsoft.Owin.Hosting;

namespace ACS.StartTrekTesting
{
    public class CrewManifestsPageObject : PageObject
    {
        string baseAddress = "http://localhost:64828/";

        public CrewManifestsPageObject()
        {
            WebApp.Start<Startup>(url: baseAddress);
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseAddress + "api/CrewManifests").Result;

            // Start website


            Initialize();
        } 
    }
}
