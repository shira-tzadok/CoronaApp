using EpidemiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EpidemiologyReport.Tests
{
    public class PatientControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public PatientControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetPatientByFirstName_ReturnPatientsList()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/Patient/GetPatientByFirstName/Yonatan");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void AddPatient_ReturnBadRequest()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Patient/AddPatient/111");
            request.Content = new StringContent(JsonConvert.SerializeObject(InitLists.PatientList), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();
            var response = await client.SendAsync(request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
