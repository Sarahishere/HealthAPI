

using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace CardsApi.Services.Health
{
    public class ApiHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var url = "https://airport-info.p.rapidapi.com/airport";
            var client = new RestClient();
            var request = new RestRequest(url,Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddHeader("X-RapidAPI-Key", "a346d191cemshba240d89da784cbp16391bjsnd23bde3c582b");
            request.AddHeader("X-RapidAPI-Host", "airport-info.p.rapidapi.com");
            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}