using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Geographic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using Utf8Json;

namespace GoingTo_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("https://goingto.azurewebsites.net/api");

            var request = new RestRequest("/categories", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Category { Name = "a la categoria"});

            var response = client.Execute<Category>(request);

            //var desearilize = new JsonDeserializer();
            //var output = desearilize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["name"];


            Assert.AreEqual(response.Data.Name, "a la categoria","No es correcto");

        }
        [TestMethod]
        public void TestMethod2()
        {
            var client = new RestClient("https://goingto.azurewebsites.net/api");

            var request = new RestRequest("/categories/{categoryid}", Method.GET);
            request.AddUrlSegment("categoryId", 1);

            var response = client.Execute<Category>(request).Content;
        }

        [TestMethod]
        public void TestMethod3()
        {
            var client = new RestClient("https://goingto.azurewebsites.net/api");

            var request = new RestRequest("/estates/{estateId}/reviews", Method.GET);
            request.AddUrlSegment("estateId", 1);

            var response = client.Execute<Review>(request).Content;
        }


    }
}
