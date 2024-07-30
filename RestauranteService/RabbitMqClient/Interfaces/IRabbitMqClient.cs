using RestauranteService.Dtos;

namespace RestauranteService.RabbitMqClient.Interfaces
{
    public interface IRabbitMqClient
    {
        public void PublicarRestaurante(RestauranteCreateDto restauranteCreateDto);
    }
}
