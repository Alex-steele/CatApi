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
        public async Task GetBreeds_NoMatchingBreed_Returns404()
        {
            var response = await client.GetAsync("breeds/someNonExistentBreed");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task GetBreeds_InvalidInput_Returns400()
        {
            var response = await client.GetAsync("breeds/" + new string('a', 51));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task GetBreeds_ValidInput_Returns200()
        {
            var response = await client.GetAsync("breeds/cat");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetBreeds_AppThrowsError_Returns500()
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
            var response = await testClient.GetAsync("breeds/" + searchTerm);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        [Test]
        public async Task GetBreeds_ValidInput_ReturnsExpectedResult()
        {
            var response = await client.GetFromJsonAsync<BreedModel[]>("breeds/ragdoll");

            Assert.That(response.First().Name.ToLower(), Is.EqualTo("ragdoll"));
        }

        [Test]
        public async Task GetImageUrls_NoUrlsForGivenId_Returns404()
        {
            var response = await client.GetAsync("images/someNonExistentImage");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task GetImageUrls_ImagesFound_Returns200()
        {
            var response = await client.GetAsync("images/mcoo");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetImageUrls_AppThrowsError_Returns500()
        {
            //Arrange
            const string id = "Test";

            var fakeGetImageUrlsQuery = A.Fake<IGetImageUrlsQuery>();
            A.CallTo(() => fakeGetImageUrlsQuery.ExecuteAsync(id)).Throws(new Exception());

            var testClient = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient(s => fakeGetImageUrlsQuery);
                });
            }).CreateClient();

            //Act
            var response = await testClient.GetAsync("images/" + id);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}
