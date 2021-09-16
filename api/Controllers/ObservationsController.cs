using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using api.Models;
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

        [HttpPost]
        public async Task<int> Create(Observation observation)
        {
            var sql = "INSERT INTO Observations (Description) Values (@Description);";
            var affectedRows = await _connection.ExecuteAsync(sql, new { Description = observation.Description }).ConfigureAwait(false);
            _logger.LogInformation($"affectedRows {affectedRows}");
            return affectedRows;
        }
    }
}
