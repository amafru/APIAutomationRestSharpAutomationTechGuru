using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIAutomationRestSharpFirst.Steps
{
    [Binding]
    public sealed class APIApplication
    {
        [Given(@"I have an endpoint (.*)")]
        public void GivenIHaveAnEndpointEndpoint(string endpoint)
        {
            RestAPIHelper.SetUrl(endpoint);
        }

        [When(@"I call GET method of API")]
        public void WhenICallGETMethodOfAPI()
        {
            RestAPIHelper.CreateRequest();
        }

        [Then(@"I should get the correct API response in json format")]
        public void ThenIShouldGetTheCorrectAPIResponseInJsonFormat()
        {
            var expected = "something"; //something is a placeholder

            var response = RestAPIHelper.GetResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Assert.That(response.Content, Is.EqualTo(expected), "Error Message");
            }
        }
        //base url for this test below (Getting user information by passing userid as an argument in scenario outline)
        //http://mydomain.com/userinformation/userid

        [When(@"I call the GET method to get user information using (.*)")]
        public void WhenICallTheGETMethodToGetUserInformationUsing(string userId)
        {
            RestAPIHelper.CreateRequest(userId);
        }

        [Then(@"I will get the user information")]
        public void ThenIWillGetTheUserInformation()
        {
            var response = RestAPIHelper.GetResponse();
        }


        //base url for this test below (Getting user information by passing 'userid' and 'accountNumber' as arguments in scenario outline)
        //http://mydomain.com/userinformation/userid/AccountInformation?account={accountNumber}

        [When(@"I call GET method using (.*) and (.*)")]
        public void WhenICallGETMethodUsing(string userId, long accountNumber)
        {
            RestAPIHelper.CreateRequest(userId, accountNumber);
        }

        [Then(@"I will get user account information")]
        public void ThenIWillGetUserAccountInformation()
        {
            var response = RestAPIHelper.GetResponse();
        }


        //POST scenario

        [When(@"I call a POST method to register a user")]
        public void WhenICallAPOSTMethodToRegisterAUser()
        {
            RestAPIHelper.CreatePostRequest();
        }

        [Then(@"I will be registered successfully")]
        public void ThenIWillBeRegisteredSuccessfully()
        {
            var response = RestAPIHelper.GetResponse();
            Assert.That(response.StatusCode, Is.EqualTo(201), "User not registered successfully");
        }


    }
}
