using RestauranteService.Dtos;

namespace RestauranteService.Http.Interfaces
{
    public interface IItemServiceHttpClient
    {
        public void AdicionaRestaurante(RestauranteReadDto readDto);
    }
}
