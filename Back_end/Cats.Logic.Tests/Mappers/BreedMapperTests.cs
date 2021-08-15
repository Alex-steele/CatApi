using System.Linq;
using Cats.Logic.Mappers;
using Cats.Service.Entities;
using NUnit.Framework;

namespace Cats.Logic.Tests.Mappers
{
    public class BreedMapperTests
    {
        private readonly BreedMapper mapper = new BreedMapper();

        [Test]
        public void Mapper_MapsCorrectly()
        {
            //Arrange
            var input = new[]
            {
                new Breed
                {
                    Weight = new Weight
                    {
                        Metric = "Test Weight"
                    },
                    Id = "Test Id",
                    Name = "Test Name",
                    Temperament = "Test Temp",
                    Origin = null,
                    Description = "Test Desc",
                    LifeSpan = "Test Life",
                    Indoor = 1,
                    Lap = 0,
                    AffectionLevel = 4,
                    ChildFriendly = 5,
                    DogFriendly = null,
                    EnergyLevel = 2,
                    Grooming = 3,
                    HealthIssues = 4,
                    Intelligence = null,
                    SheddingLevel = 4,
                    SocialNeeds = 3,
                    Vocalisation = 2,
                    Hairless = 0,
                    Rare = 1,
                    WikipediaUrl = "Test Wiki",
                    Hypoallergenic = null,
                    ReferenceImageId = "Test Ref"
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.That(result.Single().Weight, Is.EqualTo("Test Weight"));
            Assert.That(result.Single().Id, Is.EqualTo("Test Id"));
            Assert.That(result.Single().Name, Is.EqualTo("Test Name"));
            Assert.That(result.Single().Temperament, Is.EqualTo("Test Temp"));
            Assert.That(result.Single().Origin, Is.Null);
            Assert.That(result.Single().Description, Is.EqualTo("Test Desc"));
            Assert.That(result.Single().LifeSpan, Is.EqualTo("Test Life"));
            Assert.That(result.Single().Indoor, Is.True);
            Assert.That(result.Single().Lap, Is.False);
            Assert.That(result.Single().AffectionLevel, Is.EqualTo(4));
            Assert.That(result.Single().ChildFriendly, Is.EqualTo(5));
            Assert.That(result.Single().DogFriendly, Is.Null);
            Assert.That(result.Single().EnergyLevel, Is.EqualTo(2));
            Assert.That(result.Single().Grooming, Is.EqualTo(3));
            Assert.That(result.Single().HealthIssues, Is.EqualTo(4));
            Assert.That(result.Single().Intelligence, Is.Null);
            Assert.That(result.Single().SheddingLevel, Is.EqualTo(4));
            Assert.That(result.Single().SocialNeeds, Is.EqualTo(3));
            Assert.That(result.Single().Vocalisation, Is.EqualTo(2));
            Assert.That(result.Single().Hairless, Is.False);
            Assert.That(result.Single().Rare, Is.True);
            Assert.That(result.Single().WikipediaUrl, Is.EqualTo("Test Wiki"));
            Assert.That(result.Single().Hypoallergenic, Is.Null);
            Assert.That(result.Single().ReferenceImageId, Is.EqualTo("Test Ref"));

        }
    }
}
