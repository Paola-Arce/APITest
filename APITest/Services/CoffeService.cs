using APITest.Models;

namespace APITest.Services
{
    public class CoffeService : ICoffeService
    {
        private List<Coffe> _coffes = new List<Coffe>()
     {
        new Coffe() { Id=1, Name = "Premium", Brand = "Juan Valdez" },

        new Coffe() { Id = 2, Name = "Lucifer's Roast Expreso", Brand = "Kiqo" }
     };
        public IEnumerable<Coffe> Get() => _coffes;

        public Coffe? Get(int id) => _coffes.FirstOrDefault(d => d.Id == id);
    }

   
}
