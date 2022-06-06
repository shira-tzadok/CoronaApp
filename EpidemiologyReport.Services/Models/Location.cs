using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.Services.Models
{
    public class Location
    {
        [StringLength(15)]
        public string City { get; set; }

        [Required(ErrorMessage ="This field needs a value!")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

    }
}
