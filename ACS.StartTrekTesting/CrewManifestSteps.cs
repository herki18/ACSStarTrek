using TechTalk.SpecFlow;

namespace ACS.StartTrekTesting
{
    [Binding]
    public sealed class CrewManifestSteps
    {
        [Given(@"You have web page address")]
        public void GivenYouHaveWebPageAddress()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"testing something")]
        public void GivenTestingSomething()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I go there")]
        public void WhenIGoThere()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Page should be CrewManifest")]
        public void ThenPageShouldBeCrewManifest()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
