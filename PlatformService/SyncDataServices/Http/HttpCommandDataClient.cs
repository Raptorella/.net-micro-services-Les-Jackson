using System.Text;
using System.Text.Json;
using PlatformService.DTOs;
using Microsoft.Extensions.Configuration;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public HttpCommandDataClient(HttpClient client, IConfiguration config)
        {
            _httpClient = client;
            _config = config;
        }

        public async Task SendPlatformToCommandService(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");
            
            var response = 
            await _httpClient.PostAsync($"{_config["CommandService"]}", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("\n-----> Sync POST to command service was OK! ");
            }
            else{
                Console.WriteLine("\n-----> Sync POST to command service was NOT OK! ");
            }
        }
    }
}