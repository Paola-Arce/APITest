using APITest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoffeController : ControllerBase
    {
        private readonly ICoffeService _coffeService;

        public CoffeController(ICoffeService service)
        {
            _coffeService = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_coffeService.Get());

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            var coffe = _coffeService.Get(Id);
            if (coffe == null)
                return NotFound();

            return Ok(coffe);
        }
    }
}
