using Asp.Backend.API.Models;

namespace Asp.Backend.API.Services
{
    public class BeerService : IBeerService
    {
        private List<Beer> _beer = new List<Beer>()
        {
            new Beer()
            {
                Id = 1,
                Name = "Corona",
                Brand = "Modelo"
            },
            new Beer()
            {
                Id = 2,
                Name = "Pikantus",
                Brand = "Erdiger"
            }
        };

        public IEnumerable<Beer> Get() => _beer;

        public Beer? Get(int id) =>
            _beer.FirstOrDefault(d => d.Id == id);
    }
}
