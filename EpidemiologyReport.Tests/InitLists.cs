using EpidemiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemiologyReport.Tests
{
    public class InitLists
    {
        public static List<Location> location1 = new List<Location>()
        {
            new Location() {City="bnei brack",StartDate=new DateTime(2020/8/1),EndDate=new DateTime(2020/8/1),Description="Restaurant" },
            new Location() {City="Jerusalem",StartDate=new DateTime(2020/8/6),EndDate=new DateTime(2020/8/10),Description="Hotel" }
        };

        public static List<Location> location2 = new List<Location>()
        {
            new Location() {City="Ashdod",StartDate=new DateTime(2020/8/1),EndDate=new DateTime(2020/8/1),Description="Restaurant" },
            new Location() {City="elad",StartDate=new DateTime(2020/8/6),EndDate=new DateTime(2020/8/10),Description="Hotel" }
        };
        public static List<Patient> PatientList { get; set; } = new List<Patient>()
        {
            new Patient(){PatientId=111,LastName="Cohen",FirstName="Yonatan", LocationList=location1 },
            new Patient(){PatientId=222,LastName="Levi",FirstName="Shimon", LocationList=location2 },
        };

    }
}
