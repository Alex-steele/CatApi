﻿using System.Linq;
using Cats.Service.Adapters.Interfaces;
using Cats.Service.Entities;
using Cats.Service.Services;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cats.Service.Tests.Services
{
    public class CatServiceTests
    {
        private IHttpClient fakeClient;
        private IConfigurationRoot fakeConfigRoot;
        private CatService sut;

        [SetUp]
        public void SetUp()
        {
            fakeClient = A.Fake<IHttpClient>();
            fakeConfigRoot = A.Fake<IConfigurationRoot>();

            sut = new CatService(fakeClient, fakeConfigRoot);
        }

        [Test]
        public async Task CatsApi_ReturnsNull_ReturnsEmptyArray()
        {
            //Arrange
            A.CallTo(() => fakeClient.GetAndDeserializeAsync<Breed[]>(A<string>.Ignored))
                .Returns((Breed[])null);

            //Act
            var result = await sut.GetBreeds("Test");

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public async Task CatsApi_ReturnsEmpty_ReturnsEmptyArray()
        {
            //Arrange
            A.CallTo(() => fakeClient.GetAndDeserializeAsync<Breed[]>(A<string>.Ignored))
                .Returns(new Breed[0]);

            //Act
            var result = await sut.GetBreeds("Test");

            //Assert
            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public async Task CatsApi_ReturnsBreeds_ReturnsCorrectResult()
        {
            //Arrange
            var expectedResult = new[]
            {
                new Breed
                {
                    Name = "Test cat 1"
                },
                new Breed
                {
                    Name = "Test cat 2"
                }
            };

            A.CallTo(() => fakeClient.GetAndDeserializeAsync<Breed[]>(A<string>.Ignored))
                .Returns(expectedResult);

            //Act
            var result = await sut.GetBreeds("Test");

            //Assert
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo(expectedResult.First().Name));
            Assert.That(result.Last().Name, Is.EqualTo(expectedResult.Last().Name));
        }
    }
}
