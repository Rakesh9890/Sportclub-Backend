

using Twilio.Clients;
using Twilio.Http;


namespace SportsProject.Services
{
    public class Twiloclient:ITwilioRestClient
    {

        private readonly ITwilioRestClient innerClient;
        public Twiloclient(IConfiguration config, System.Net.Http.HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "Custom TwilloRestClient-Demo");
            innerClient = new TwilioRestClient(
                config["Twilio:AccountSid"],
                config["Twilio:AuthToken"],
                httpClient: new SystemNetHttpClient(httpClient));
        }

        public string AccountSid => innerClient.AccountSid;

        public string Region => innerClient.Region;

        public Twilio.Http.HttpClient HttpClient => innerClient.HttpClient;

        public Response Request(Request request)
         {
            return innerClient.Request(request);
         }

         public Task<Response> RequestAsync(Request request)
         {
            return innerClient.RequestAsync(request);
         }
    }
               
}