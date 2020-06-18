using System;
using TechTalk.SpecFlow;

namespace GoingTo_Test
{
    [Binding]
    public class EditPartnerEstatesSteps
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
        
        [Then(@"I receive a estates resource list")]
        public void ThenIReceiveAEstatesResourceList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the estate resource I posted")]
        public void ThenIReceiveTheEstateResourceIPosted()
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
