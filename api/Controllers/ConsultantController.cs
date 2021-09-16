using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("consultant")]
    public class IndexController : ControllerBase
    {
     

        private readonly ILogger<IndexController> _logger;

        public IndexController(ILogger<IndexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get () => "all the consultants";
    }
}
