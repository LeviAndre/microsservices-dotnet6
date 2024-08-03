using AutoMapper;
using ItemService.Data;
using ItemService.Dtos;
using ItemService.EventProccessor.Interfaces;
using ItemService.Models;
using System.Text.Json;

namespace ItemService.EventProccessor
{
    public class EventProccessor : IEventProccessor
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProccessor(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void Proccess(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var itemRepository = scope.ServiceProvider.GetRequiredService<IItemRepository>();

            RestauranteReadDto restauranteReadDto = JsonSerializer.Deserialize<RestauranteReadDto>(message);

            Console.WriteLine(restauranteReadDto);

            Restaurante restaurante = _mapper.Map<Restaurante>(restauranteReadDto);

            Console.WriteLine(restaurante);

            if (itemRepository.RestauranteExiste(restaurante.Id))
            {
                itemRepository.CreateRestaurante(restaurante);
                itemRepository.SaveChanges();
            }
        }
    }
}
