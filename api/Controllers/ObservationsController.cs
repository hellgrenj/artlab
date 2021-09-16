using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NpgsqlTypes;

namespace api.Controllers
{
    [ApiController]
    [Route("observation")]
    public class ObservationController : ControllerBase
    {
        private readonly ILogger<ObservationController> _logger;
        private readonly IDbConnection _connection;
        private readonly IHttpClientFactory _clientFactory;

        public ObservationController(ILogger<ObservationController> logger, IDbConnection connection, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _connection = connection;
            _clientFactory = clientFactory;
        }
        [HttpGet]
        public async Task<IEnumerable<Observation>> Get() => await _connection.QueryAsync<Observation>("Select * From Observations").ConfigureAwait(false);

        [HttpPost]
        public async Task<int> Create(Observation observation)
        {
            var location = await GetCoordinatesAsync(observation.City);
            var sql = "INSERT INTO Observations (Description, City, Lat, Long) Values (@Description, @City, @Lat, @Long) RETURNING Id;";
            var createdId = await _connection.ExecuteScalarAsync(sql,
            new { Description = observation.Description, City = observation.City, Lat = location.Lat, Long = location.Long }).ConfigureAwait(false);
            _logger.LogInformation($"created new observation with id {createdId}");
            return (int)createdId;
        }
        private async Task<Location> GetCoordinatesAsync(string place)
        {
            var client = _clientFactory.CreateClient("location");
            var jsonPayload = new StringContent(JsonSerializer.Serialize(new string[] { place }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/location", jsonPayload);
            List<Location> locations = new();
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                locations = await JsonSerializer.DeserializeAsync<List<Location>>(responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
            }
            if (locations.Count > 0)
            {
                return locations[0];
            }
            else
            {
                return new(string.Empty, 0, 0);
            }
        }
        private record Location(string Name, double Lat, double Long);
    }
}
