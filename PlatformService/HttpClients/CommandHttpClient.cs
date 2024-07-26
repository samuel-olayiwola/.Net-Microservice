using PlatformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.HttpClients
{
    public class CommandHttpClient : ICommandHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CommandHttpClient(HttpClient httpClient, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendCommand(PlatformResponseDto msg)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(msg),Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync($"{_configuration["Command_Url"]}/api/platform", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("************* Command sent successfully **************");
            }

            else
            {
                Console.WriteLine("*********** an error occured while sending command**************");
            }
        }
    }
}
