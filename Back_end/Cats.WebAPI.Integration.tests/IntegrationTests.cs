using Cats.Logic.Models;
using Cats.Logic.Queries.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cats.WebAPI.Integration.tests
{
    public class IntegrationTests
    {
        private CustomWebApplicationFactory<Startup> factory;
        private HttpClient client;

        [SetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory<Startup>
            {
                ClientOptions = {BaseAddress = new Uri("https://localhost:44398/cats/")}
            };
            client = factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            factory.Dispose();
        }

        [Test]
        public async Task Path_DoesNotMatchAnyController_Returns404()
        {
            var response = await client.GetAsync("");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Get_InvalidInput_Returns400()
        {
            var response = await client.GetAsync(new string('a', 51));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task Get_ValidInput_Returns200()
        {
            var response = await client.GetAsync("cat");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Get_ValidInput_ReturnsExpectedResult()
        {
            var response = await client.GetFromJsonAsync<BreedModel[]>("ragdoll");

            Assert.That(response.First().Name.ToLower(), Is.EqualTo("ragdoll"));
        }

        [Test]
        public async Task Error_AppThrowsError_Returns500()
        {
            //Arrange
            const string searchTerm = "Test";

            var fakeGetBreedsQuery = A.Fake<IGetBreedsQuery>();
            A.CallTo(() => fakeGetBreedsQuery.ExecuteAsync(searchTerm)).Throws(new Exception());

            var testClient = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient(s => fakeGetBreedsQuery);
                });
            }).CreateClient();

            //Act
            var response = await testClient.GetAsync(searchTerm);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}
