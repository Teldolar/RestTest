using System;
using System.IO;
using System.Net;
using Aquality.Selenium.Browsers;
using RestSharp;

namespace TestProject1.Utils
{
    public static class ApiUtils
    {
        public static (int,string) Post(string url, string json)
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(url);
            restRequest.AddJsonBody(json);
            var answer = restClient.Post(restRequest);
            return ((int)answer.StatusCode, answer.Content);
        }

        public static (int,string) Get(string url)
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(url);
            var asd = restClient.Get(restRequest);
            return ((int)asd.StatusCode, asd.Content);
        }
    }
}