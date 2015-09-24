using ACS.TestCore;
using NUnit.Framework;
using OpenQA.Selenium;
using Protractor;
using TechTalk.SpecFlow;

namespace ACS.StartTrekTesting
{
    [Binding]
    public sealed class CrewManifestSteps : PageObject
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

        [Given(@"the \{Crew Manifest} is open")]
        public void GivenTheCrewManifestIsOpen()
        {
            Engine.GoToUrl("localhost:64834");
            Engine.CollectLogsFromBrowser();
        }

        [When(@"the \{Crew Manifest} is selected")]
        public void WhenTheCrewManifestIsSelected()
        {
            Assert.AreEqual("http://localhost:64834/", Engine.NgWebDriver.Url);
            Engine.CollectLogsFromBrowser();
        }

        [Then(@"the \{Crew Manifest} should be Star Trek")]
        public void ThenTheCrewManifestShouldBeStarTrek()
        {
            Assert.AreEqual("Star Trek", Engine.FindElementById("Page Title"));
            Engine.CollectLogsFromBrowser();
        }

        [Then(@"the \{Add and Remove Crew} button is present")]
        public void ThenTheAddAndRemoveCrewButtonIsPresent()
        {
            Engine.CollectLogsFromBrowser();
        }

        [Then(@"the \{number of crew displayed} should be \{number = (.*)}")]
        public void ThenTheNumberOfCrewDisplayedShouldBeNumber(int p0)
        {
            Engine.CollectLogsFromBrowser();
        }

    }
}
