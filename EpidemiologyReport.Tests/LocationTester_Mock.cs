using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpidemiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using Xunit;
using EpidemiologyReport.Api.Controllers;
using System.Net;
using EpidemiologyReport.DAL;
using EpidemiologyReport.Services.Repositorieis;

namespace EpidemiologyReport.Tests
{
    public class LocationTester_Mock : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public LocationTester_Mock(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void AddLocationList_ReturnOK()
        {            
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(x => x.AddLocation(new List<Location>(), 0)).Returns(Task.FromResult(new List<Location>() ));

            var locationController = new LocationController(mock.Object);
            var response = await locationController.AddLocation(new List<Location>(),0);
            Assert.True(response != null);
        }

        [Fact]
        public async void GetLocationByCity_ReturnError()
        {
            List<Location> l = null;
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(x => x.GetLocationByCity(String.Empty)).Returns(Task.FromResult(l));

            var locationController = new LocationController(mock.Object);
            var response = await locationController.GetLocationByCity("Jerusalem");
            Assert.True(response==null);
        }
    }
}
