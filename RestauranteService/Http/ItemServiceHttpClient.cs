using RestauranteService.Dtos;
using RestauranteService.Http.Interfaces;
using System.Text;
using System.Text.Json;

namespace RestauranteService.Http
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public ItemServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async void AdicionaRestaurante(RestauranteReadDto readDto)
        {
            var bodyHttp = new StringContent
                (
                    JsonSerializer.Serialize(readDto),
                    Encoding.UTF8,
                    "application/json"
                );

            await _httpClient.PostAsync(_configuration["ItemService"], bodyHttp);
        }
    }
}
