using EpidemiologyReport.Services.Models;
using EpidemiologyReport.Services.Repositorieis;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EpidemiologyReport.DAL
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ILogger<PatientRepository> _logger;
        public PatientRepository(ILogger<PatientRepository> logger)
        {
            _logger = logger;
        }
        public async Task<List<Patient>> AddPatient(Patient patient, int id)
        {
            _logger.LogInformation($"AddPatient from PatientConroller called with id {id}");
            try
            {
                Patient p = DB.PatientList.First(p => p.PatientId == id);
                //_logger.Information($"patient with id {id} added successfully");
                DB.PatientList.Add(patient);
                return await Task.FromResult(DB.PatientList);
            }
            catch (Exception)
            {
                throw;
            }
            _logger.LogError($"patient with id {id} allready exists");
        }

        public async Task<List<Patient>> DeletePatientById(int id)
        {
            try
            {
                _logger.LogInformation($"DeletePatientById from PatientConroller called with id {id}");
                Patient patient = DB.PatientList.FirstOrDefault(p => p.PatientId == id);
                DB.PatientList.Remove(patient);
                _logger.LogWarning($"patient with id {id} deleted");
            }
            catch (Exception)
            {
                _logger.LogError($"patient with id {id} not exist");
            }
            return await Task.FromResult(DB.PatientList);
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            _logger.LogInformation("GetAllPatients from PatientConroller called");
            return await Task.FromResult(DB.PatientList);
        }

        public async Task<List<Patient>> GetPatientByLastName(string lastName)
        {
            _logger.LogInformation($"GetPatientByLastName from PatientConroller called with lastName {lastName}");
            return await Task.FromResult(DB.PatientList.Where(p => p.LastName == lastName).ToList());
        }

        public async Task<List<Patient>> GetPatientByFirstName(string firstName)
        {
            _logger.LogInformation($"GetPatientByFirstName from PatientConroller called with firstName {firstName}");
            return await Task.FromResult(DB.PatientList.Where(p => p.FirstName == firstName).ToList());
        }

        public async Task<Patient> GetPatientById(int id)
        {
            _logger.LogInformation($"GetPatientById from PatientConroller called with id {id}");
            return await Task.FromResult(DB.PatientList.First(p => p.PatientId == id));
        }
    }
}
