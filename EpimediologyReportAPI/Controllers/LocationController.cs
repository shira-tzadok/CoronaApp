using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EpidemiologyReport.Services.Repositorieis;
using EpidemiologyReport.Services.Models;
using Moq;

namespace EpidemiologyReport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<List<Location>> GetLocations()
        {
            return await _locationRepository.GetLocations();
        }

        [HttpGet("{city}")]
        public async Task<List<Location>> GetLocationByCity(string city)
        {
            return await _locationRepository.GetLocationByCity(city);
        }

        [HttpGet("{id}")]
        public async Task<List<Location>> GetLocationByPatientId(int id)
        {
            return await _locationRepository.GetLocationByPatientId(id);
        }

        [HttpPost("{id}")]
        public async Task<List<Location>> AddLocation([FromBody] List<Location> newLocation, [FromRoute] int id)
        {
            Task<List<Location>> locations = _locationRepository.AddLocation(newLocation, id);
            //return await Task.FromResult(NotFound());
            return await Task.FromResult(newLocation);
        }

        [HttpDelete("{id}")]
        public async Task<List<Location>> DeleteLocationById(int id)
        {
            return await _locationRepository.DeleteLocationById(id);
        }
    }
}
