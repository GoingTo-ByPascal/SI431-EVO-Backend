using System;
using TechTalk.SpecFlow;

namespace GoingTo_Test
{
    [Binding]
    public class EditPartnerProfileSteps
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
        
        [Then(@"I receive a profile resource list")]
        public void ThenIReceiveAProfileResourceList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the profile resource I posted")]
        public void ThenIReceiveTheProfileResourceIPosted()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the estate resource I deleted")]
        public void ThenIReceiveTheEstateResourceIDeleted()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
