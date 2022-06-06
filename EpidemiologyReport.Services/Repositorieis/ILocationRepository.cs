using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Repositorieis
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocations();
        Task<List<Location>> GetLocationByCity(string city);
        Task<List<Location>> GetLocationByPatientId(int id);
        Task<List<Location>> AddLocation(List<Location> newLocation, int id);
        Task<List<Location>> DeleteLocationById(int id);
    }
}
