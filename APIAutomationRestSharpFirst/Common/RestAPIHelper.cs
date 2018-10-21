using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationRestSharpFirst
{
    public static class RestAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = "http://mydomain.com/";

        public static RestClient  SetUrl(string endpoint)
        {
            var url = baseUrl + endpoint;
            return client = new RestClient(url);
        }

        public static RestRequest CreateRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            return restRequest;
        }

        //CreateRequest Method for Scenario 2 (Scenario outline passing UserId)

            public static RestRequest CreateRequest(string userId)
        {
            var resource = userId;
            restRequest = new RestRequest(resource, Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            return restRequest;
        }

        //base url for this test below (Getting user information by passing 'userid' and 'accountNumber' as arguments in scenario outline)
        //http://mydomain.com/userinformation/userid/AccountInformation?account={accountNumber}

        public static RestRequest CreateRequest(string userId, long accountNumber)
        {
            var resource = userId + "/AccountInformation?account={accountNumber}";
            restRequest = new RestRequest(resource, Method.GET);
            restRequest.AddParameter("accountNumber", accountNumber, ParameterType.UrlSegment);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
             return client.Execute(restRequest);
        }

       //create Request for Post method

        public static RestRequest CreatePostRequest()
        {
            var userInfo = new UserInformation();
            userInfo.firstName = "Tej";
            userInfo.lastName = "Pal";
            userInfo.emailAddress = "tejpal@email.com";
            userInfo.dateOfBirth = new DateTime(1981, 1, 1);

            var resource = "/registration/";
            restRequest = new RestRequest(resource, Method.POST);
            restRequest.AddBody(userInfo);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

       
    }
}
