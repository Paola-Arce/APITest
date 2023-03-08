using APITest.Models;

namespace APITest.Services
{
    public interface ICoffeService
    {
        public IEnumerable<Coffe> Get();
        public Coffe? Get(int id);

    }
}
