using EpidemiologyReport.Services.Models;
using EpidemiologyReport.Services.Repositorieis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemiologyReport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpPost("{id}")]
        public async Task<List<Patient>> AddPatient([FromBody] Patient patient, [FromRoute] int id)
        {

            Task<List<Patient>> patients = _patientRepository.AddPatient(patient, id);
            return await patients;
        }

        [HttpDelete("{id}")]
        public async Task<List<Patient>> DeletePatientById(int id)
        {
            return await _patientRepository.DeletePatientById(id);
        }

        [HttpGet]
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        [HttpGet("{lastName}")]
        public async Task<List<Patient>> GetPatientByLastName(string lastName)
        {
            return await _patientRepository.GetPatientByLastName(lastName);
        }

        [HttpGet("{firstName}")]
        public async Task<List<Patient>> GetPatientByFirstName(string firstName)
        {
            return await _patientRepository.GetPatientByFirstName(firstName);
        }

        [HttpGet("{id}")]
        public async Task<Patient> GetPatientById(int id)
        {
            return await _patientRepository.GetPatientById(id);
        }
    }
}
