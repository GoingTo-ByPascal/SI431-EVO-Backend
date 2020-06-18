using System;
using TechTalk.SpecFlow;

namespace GoingTo_Test
{
    [Binding]
    public class AddNewServicesToEstateSteps
    {
        [When(@"I make a Post request to ""(.*)""")]
        public void WhenIMakeAPostRequestTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I make a Delete request to ""(.*)""")]
        public void WhenIMakeADeleteRequestTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive a services resource list")]
        public void ThenIReceiveAServicesResourceList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the service resource I posted")]
        public void ThenIReceiveTheServiceResourceIPosted()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the service resource I deleted")]
        public void ThenIReceiveTheServiceResourceIDeleted()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
