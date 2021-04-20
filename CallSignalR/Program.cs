using RestSharp;
using System;

namespace CallSignalR
{
    class Program
    {
        private static readonly RestClient restClient = new RestClient();
        static void Main(string[] args)
        {
            string value = null, name = null;
            restClient.BaseUrl = new Uri("http://localhost:5000/");
            var request = new RestRequest($"/api/Values/SetValues", Method.GET);
            request.AddHeader("Accept", "application/json");
            SetValues(args, ref value, ref name);
            request.AddQueryParameter("name", name ?? "anonymous");
            request.AddQueryParameter("value", value ?? "55");
            IRestResponse response = restClient.Execute(request);
            Console.WriteLine(response.IsSuccessful ? "Success" : "Fail");
        }

        private static void SetValues(string[] args, ref string value, ref string name)
        {
            if (args.Length != 0)
            {
                name = args[0];
                value = args[1];
            }
        }
    }
}
