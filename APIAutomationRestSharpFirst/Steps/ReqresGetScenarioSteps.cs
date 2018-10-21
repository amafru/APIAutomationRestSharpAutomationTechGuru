using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIAutomationRestSharpFirst.Steps
{
    [Binding]
    public sealed class ReqresGetScenarioSteps
    {
        [Given(@"I have a reqres endpoint (.*)")]
        public void GivenIHaveAReqresEndpointApiUsersPage(string endpoint)
        {
            RestAPIHelper.SetUrl(endpoint);
        }

        [When(@"I call the GET http method of API")]
        public void WhenICallTheGETHttpMethodOfAPI()
        {
            RestAPIHelper.CreateRequest();
        }

        [Then(@"I should get back the correct response in json format")]
        public void ThenIShouldGetBackTheCorrectResponseInJsonFormat()
        {
            var StatusCode = "200 OK";
            var response = RestAPIHelper.GetResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Assert.That(response.StatusCode, Is.EqualTo(StatusCode), "Returned result not as expected");
            }
            
        }

    }
}
