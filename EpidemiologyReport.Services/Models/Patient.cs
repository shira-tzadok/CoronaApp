using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Models
{
    public class Patient
    {
        [Required]
        public int PatientId { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<Location> LocationList { get; set; }
    }
}
