using Microsoft.Extensions.Configuration;
using PlatformService.DTOs;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(
                    JsonSerializer.Serialize(platform),
                    Encoding.UTF8,
                    "application/json");

            var response = await _httpClient.PostAsync(_configuration["CommandServiceUrl"], httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> sync POST to CommandService was Ok!");
            }
            else
            {
                Console.WriteLine("--> sync POST to CommandsService was OK!");
            }
        }
    }
}
