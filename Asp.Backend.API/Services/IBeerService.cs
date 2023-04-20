using Asp.Backend.API.Models;

namespace Asp.Backend.API.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> Get();
        public Beer? Get(int id);
    }
}
