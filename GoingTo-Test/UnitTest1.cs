using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace GoingTo_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var client = new RestClient("https://goingto.azurewebsites.net/api");

            var request = new RestRequest("/categories/{categoryId}",Method.GET);
            request.AddUrlSegment("categoryId", 1);

            var content = client.Execute(request).Content;
        }
    }
}
