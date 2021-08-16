using Cats.Logic.Queries;
using Cats.Logic.Validators.Interfaces;
using Cats.Logic.Wrappers.Enums;
using Cats.Service.Entities;
using Cats.Service.Services.Interfaces;
using FakeItEasy;
using FluentValidation.Results;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Cats.Logic.Tests.Queries
{
    public class GetBreedsQueryTests
    {
        private IGetBreedsValidator fakeValidator;
        private ICatService fakeCatService;
        private GetBreedsQuery sut;

        [SetUp]
        public void SetUp()
        {
            fakeValidator = A.Fake<IGetBreedsValidator>();
            fakeCatService = A.Fake<ICatService>();

            sut = new GetBreedsQuery(fakeValidator, fakeCatService);
        }

        [Test]
        public async Task SearchTerm_Invalid_ReturnsValidationError()
        {
            //Arrange
            const string searchTerm = "Invalid search term";

            A.CallTo(() => fakeValidator.ValidateAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
                .Returns(new ValidationResult
                {
                    Errors = { new ValidationFailure("Test", "Error") }
                });

            //Act
            var result = await sut.ExecuteAsync(searchTerm);

            //Assert
            Assert.That(result.Result, Is.EqualTo(Result.ValidationError));
        }

        [Test]
        public void CatService_ReturnsNull_Throws()
        {
            //Arrange
            const string searchTerm = "Test";

            A.CallTo(() => fakeValidator.ValidateAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
                .Returns(new ValidationResult());

            A.CallTo(() => fakeCatService.GetBreeds(searchTerm))
                .Returns((Breed[])null);

            //Act & Assert
            Assert.That(async () => await sut.ExecuteAsync(searchTerm), Throws.ArgumentNullException);
        }

        [Test]
        public async Task CatService_ReturnsEmpty_ReturnsNotFound()
        {
            //Arrange
            const string searchTerm = "Test";

            A.CallTo(() => fakeValidator.ValidateAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
                .Returns(new ValidationResult());

            A.CallTo(() => fakeCatService.GetBreeds(searchTerm))
                .Returns(new Breed[0]);

            //Act
            var result = await sut.ExecuteAsync(searchTerm);

            //Assert
            Assert.That(result.Result, Is.EqualTo(Result.NotFound));
        }

        [Test]
        public async Task CatService_ReturnsArray_ReturnsSuccess()
        {
            //Arrange
            const string searchTerm = "Test";

            A.CallTo(() => fakeValidator.ValidateAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
                .Returns(new ValidationResult());

            A.CallTo(() => fakeCatService.GetBreeds(searchTerm))
                .Returns(new[]
                {
                    new Breed
                    {
                        Name = "Test cat"
                    }
                });

            //Act
            var result = await sut.ExecuteAsync(searchTerm);

            //Assert
            Assert.That(result.Result, Is.EqualTo(Result.Success));
            Assert.That(result.Payload.Length, Is.EqualTo(1));
        }

        [Test]
        public async Task CatService_ReturnsArray_ReturnsPayloadInCorrectOrder()
        {
            //Arrange
            const string searchTerm = "La";

            var expectedResult = new[]
            {
                new Breed
                {
                    Name = "Cat"
                },
                new Breed
                {
                    Name = "Lazy cat"
                },
                new Breed
                {
                    Name = "Hyper cat"
                }
            };

            A.CallTo(() => fakeValidator.ValidateAsync(A<string>.Ignored, A<CancellationToken>.Ignored))
                .Returns(new ValidationResult());

            A.CallTo(() => fakeCatService.GetBreeds(searchTerm))
                .Returns(expectedResult);

            //Act
            var result = await sut.ExecuteAsync(searchTerm);

            //Assert
            Assert.That(result.Result, Is.EqualTo(Result.Success));
            Assert.That(result.Payload.Length, Is.EqualTo(3));
            Assert.That(result.Payload[0].Name, Is.EqualTo(expectedResult[1].Name));
            Assert.That(result.Payload[1].Name, Is.EqualTo(expectedResult[0].Name));
            Assert.That(result.Payload[2].Name, Is.EqualTo(expectedResult[2].Name));
        }
    }
}
