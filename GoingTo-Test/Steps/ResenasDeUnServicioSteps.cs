using GoingTo_API.Domain.Models;
using GoingTo_Test.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace GoingTo_Test
{
    [Binding]
    public class ResenasDeUnServicioSteps
    {
        private IRestResponse _restResponse;
        private Review _review;
        private HttpStatusCode _statusCode;
        private List<Review> _reviews;


        [Given(@"I am a partner")]
        public void GivenIAmAPartner()
        {
            ScenarioContext.Current.Clear();
        }
        
        [When(@"I make a Get request to ""(.*)""")]
        public void WhenIMakeAGetRequestTo(string Id)
        {
            //_review = ScenarioContext.Current.Get<Review>();
            //var request = new HttpRequestWrapper()
            //                  .SetMethod(Method.GET)
            //                  .SetResourse("/reviews")
            //                  .AddParameter("id", _review.Id);

            //_reviews = new List<Review>();
            //_reviews = request.Execute<List<Review>>();
            var client = new RestClient("https://goingto.azurewebsites.net/api");

            var request = new RestRequest("/estate/{estateId}/reviews", Method.GET);
            request.AddUrlSegment("estateId", 1);
            _reviews = new List<Review>();
            //_reviews = request.Execute<List<Review>>();

            var response = client.Execute<Review>(request).Content;
        }
        
        [Then(@"I receive a reviews resource list")]
        public void ThenIReceiveAReviewsResourceList()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
