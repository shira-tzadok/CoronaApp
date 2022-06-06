using EpidemiologyReport.Services.Models;
using EpidemiologyReport.Services.Repositorieis;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace EpidemiologyReport.DAL
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILogger<LocationRepository> _logger;
        public LocationRepository(ILogger<LocationRepository> logger)
        {
            _logger = logger;
            //Log.Logger = new LoggerConfiguration()
            //      .MinimumLevel.Debug()
            //      .WriteTo.Console()
            //      .WriteTo.File("var/location/log.json", rollingInterval: RollingInterval.Day).CreateLogger();
            //_logger = logger;
        }
        public async Task<List<Location>> GetLocations()
        {
            _logger.LogInformation("GetLocations from LocationController called");
            return await Task.FromResult(DB.PatientList.SelectMany(patient => patient.LocationList).ToList());
        }

        public async Task<List<Location>> GetLocationByCity(string city)
        {

            _logger.LogInformation($"GetLocationByCity from LocationController called with city:{city}");
            return await Task.FromResult(DB.PatientList.SelectMany(patient => patient.LocationList).Where(location => location.City == city).ToList());
        }

        public async Task<List<Location>> GetLocationByPatientId(int id)
        {
            _logger.LogInformation($"GetLocationByPatientId from LocationController called with id:{id}");
            return await Task.FromResult(DB.PatientList.First(p => p.PatientId == id).LocationList);
        }

        public virtual async Task<List<Location>> AddLocation(List<Location> newLocation, int id)
        {
            try
            {
                _logger.LogInformation($"AddLocation from LocationController called with id:{id} and new locations {newLocation}");
                Patient patient = DB.PatientList.First(l => l.PatientId == id);
                patient.LocationList.AddRange(newLocation);
            }
            //string patientContext=JsonSerializer.Serialize(_patient,new JsonSerializerOptions() { WriteIndented = true });
            //using(StreamWriter streamWriter=new StreamWriter("DB.json"))
            //{
            //    streamWriter.WriteLine(patientContext);
            //}
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(newLocation);
        }

        public async Task<List<Location>> DeleteLocationById(int id)
        {
            try
            {
                _logger.LogInformation($"DeleteLocationById from LocationController called but id {id} not found");
                List<Location> locations = DB.PatientList.First(p => p.PatientId == id).LocationList;
                DB.PatientList.First(p => p.PatientId == id).LocationList.RemoveRange(0, locations.Count);
            }
            catch (Exception)
            {
                throw;
            }
            return await await Task.FromResult(GetLocationByPatientId(id));
        }

    }
}
