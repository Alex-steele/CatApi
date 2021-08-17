using System.Linq;
using System.Threading.Tasks;
using Cats.Logic.Queries;
using Cats.Logic.Wrappers.Enums;
using Cats.Service.Services.Interfaces;
using FakeItEasy;
using NUnit.Framework;

namespace Cats.Logic.Tests.Queries
{
    public class GetImageUrlsQueryTests
    {
        private ICatService fakeCatService;
        private GetImageUrlsQuery sut;

        [SetUp]
        public void SetUp()
        {
            fakeCatService = A.Fake<ICatService>();
            sut = new GetImageUrlsQuery(fakeCatService);
        }

        [Test]
        public void CatService_ReturnsNull_Throws()
        {
            //Arrange
            const string id = "Test";

            A.CallTo(() => fakeCatService.GetImageUrls(id))
                .Returns((string[])null);

            //Act & Assert
            Assert.That(async () => await sut.ExecuteAsync(id), Throws.ArgumentNullException);
        }

        [Test]
        public async Task CatService_ReturnsEmpty_ReturnsNotFound()
        {
            //Arrange
            const string id = "Test";

            A.CallTo(() => fakeCatService.GetImageUrls(id))
                .Returns(new string[0]);

            //Act
            var result = await sut.ExecuteAsync(id);

            //Assert
            Assert.That(result.Result, Is.EqualTo(Result.NotFound));
        }

        [Test]
        public async Task CatService_ReturnsArray_ReturnsSuccessAndCorrectPayload()
        {
            //Arrange
            const string id = "Test";

            var expectedResult = new[]
            {
                "Test1",
                "Test2"
            };

            A.CallTo(() => fakeCatService.GetImageUrls(id))
                .Returns(expectedResult);

            //Act
            var result = await sut.ExecuteAsync(id);

            //Assert
            Assert.That(result.Result, Is.EqualTo(Result.Success));
            Assert.That(result.Payload.Length, Is.EqualTo(2));
            Assert.That(result.Payload.First(), Is.EqualTo(expectedResult.First()));
            Assert.That(result.Payload.Last(), Is.EqualTo(expectedResult.Last()));
        }
    }
}
