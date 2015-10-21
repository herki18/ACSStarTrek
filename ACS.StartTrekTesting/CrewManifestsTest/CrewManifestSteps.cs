using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ACS.StartTrekTesting.CrewManifestsTest
{
    [Binding]
    public sealed class CrewManifestSteps : CrewManifestsPageObject
    {
         

        

        [Given(@"the \{Crew Manifest} is open")]
        public void GivenTheCrewManifestIsOpen()
        {
            //Engine.GoToUrl("localhost:64834");
            Engine.GoToUrl("localhost:64828");
            
        }


        [When(@"the \{Crew Manifest} is selected")]
        public void WhenTheCrewManifestIsSelected()
        {
            Assert.AreEqual("http://localhost:64828/", Engine.NgWebDriver.Url);
        }

        [Then(@"the \{Crew Manifest} should be Star Trek")]
        public void ThenTheCrewManifestShouldBeStarTrek()
        {
            //Assert.AreEqual("Star Trek", Engine.FindElementById("Page Title"));
        }

        [Then(@"the \{Add and Remove Crew} button is present")]
        public void ThenTheAddAndRemoveCrewButtonIsPresent()
        {
            //Assert.AreEqual(true, Engine.NgWebDriver.FindElement(By.Id("AddandRemoveCrew")).Enabled);
        }

        [Then(@"the \{number of crew displayed} should be \{number = (.*)}")]
        public void ThenTheNumberOfCrewDisplayedShouldBeNumber(int p0)
        {
            //Assert.AreEqual(3, Engine.NgWebDriver.TakeScreenshot()`FindElement(By.Id()));
        }

    }
}
