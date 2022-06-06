using EpidemiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit;

namespace EpidemiologyReport.Tests
{
    public class LocationControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public LocationControllerTests(WebApplicationFactory<Program> Factory)
        {
            _factory = Factory;
        }

        [Fact]
        public async void AddLocationList_ReturnOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Location/AddLocation/111");
            request.Content = new StringContent(JsonConvert.SerializeObject(InitLists.location2), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();
            var response = await client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async void GetLocationByCity_ReturnLocations()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/Location/GetLocationByCity/Jerusalem");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void GetLocationById_ReturnNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/Location/GetLocationByPatientId/22");
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}