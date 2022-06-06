using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Repositorieis
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatients();
        Task<List<Patient>> GetPatientByFirstName(string firstName);
        Task<List<Patient>> GetPatientByLastName(string lastName);
        Task<Patient> GetPatientById(int id);
        Task<List<Patient>> AddPatient(Patient patient,int id);
        Task<List<Patient>> DeletePatientById(int id);
    }
}
