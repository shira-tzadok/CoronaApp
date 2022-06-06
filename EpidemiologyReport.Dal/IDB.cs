using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.DAL
{
    public interface IDB
    {
        static List<Patient> PatientList { get; set; }
    }
}
