using System;
using TechTalk.SpecFlow;

namespace GoingTo_Test
{
    [Binding]
    public class EditPartnerPromosSteps
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
        
        [Then(@"I receive a promo resource list")]
        public void ThenIReceiveAPromoResourceList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the promo resource I posted")]
        public void ThenIReceiveThePromoResourceIPosted()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the promo resource I deleted")]
        public void ThenIReceiveThePromoResourceIDeleted()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
