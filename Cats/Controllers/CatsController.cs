using Microsoft.AspNetCore.Mvc;

namespace Cats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {

        private readonly ILogger<CatController> _logger;

        public CatController(ILogger<CatController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCat")]
        public IEnumerable<Cat> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Cat
            {
                Name = "Cat",
                Breed = "Siamese"
            })
            .ToArray();
        }
    }
}
