using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("observation")]
    public class ObservationController : ControllerBase
    {


        private readonly ILogger<ObservationController> _logger;
        private readonly IDbConnection _connection;

        public ObservationController(ILogger<ObservationController> logger, IDbConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        [HttpGet]
        public async Task<IEnumerable<Observation>> Get() => await _connection.QueryAsync<Observation>("Select * From Observations").ConfigureAwait(false);
    }
    public record Observation(int Id, string Description);
}
