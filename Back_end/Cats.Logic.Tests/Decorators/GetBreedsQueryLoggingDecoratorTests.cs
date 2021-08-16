using Cats.Logic.Decorators;
using Cats.Logic.Models;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Wrappers;
using FakeItEasy;
using FluentValidation.Results;
using NUnit.Framework;
using Serilog;
using System.Linq;
using System.Threading.Tasks;

namespace Cats.Logic.Tests.Decorators
{
    public class GetBreedsQueryLoggingDecoratorTests
    {
        private IGetBreedsQuery fakeInnerQuery;
        private ILogger fakeLogger;
        private GetBreedsQueryLoggingDecorator sut;

        [SetUp]
        public void SetUp()
        {
            fakeInnerQuery = A.Fake<IGetBreedsQuery>();
            fakeLogger = A.Fake<ILogger>();

            sut = new GetBreedsQueryLoggingDecorator(fakeInnerQuery, fakeLogger);
        }

        [Test]
        public async Task InnerQuery_ReturnsValidationError_LogsCorrectMessage()
        {
            //Arrange
            const string searchTerm = "Test";

            A.CallTo(() => fakeInnerQuery.ExecuteAsync(searchTerm))
                .Returns(ResultWrapper<BreedModel[]>.ValidationError(new ValidationResult
                {
                    Errors = { new ValidationFailure("Test", "Error") }
                }));

            //Act
            await sut.ExecuteAsync(searchTerm);

            //Assert
            A.CallTo(() => fakeLogger.Warning($"Validation error given for search term '{searchTerm}'"))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task InnerQuery_ReturnsNotFound_LogsCorrectMessage()
        {
            //Arrange
            const string searchTerm = "Test";

            A.CallTo(() => fakeInnerQuery.ExecuteAsync(searchTerm))
                .Returns(ResultWrapper<BreedModel[]>.NotFound);

            //Act
            await sut.ExecuteAsync(searchTerm);

            //Assert
            A.CallTo(() => fakeLogger.Information(($"No results found for search term '{searchTerm}'")))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task InnerQuery_ReturnsSuccess_LogsCorrectMessage()
        {
            //Arrange
            const string searchTerm = "Test";

            var innerQueryPayload = new[]
            {
                new BreedModel
                {
                    Name = "Test Name"
                }
            };

            A.CallTo(() => fakeInnerQuery.ExecuteAsync(searchTerm))
                .Returns(ResultWrapper<BreedModel[]>.Success(innerQueryPayload));

            //Act
            await sut.ExecuteAsync(searchTerm);

            //Assert
            A.CallTo(() => fakeLogger.Information($"Retrieved the following breeds for search term '{searchTerm}': {string.Join(", ", innerQueryPayload.Select(x => x.Name))}"))
                .MustHaveHappenedOnceExactly();
        }
    }
}
