using System.Collections.Generic;
using DiscographyUnited.Entities;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using Moq;
using Xunit;

namespace DiscographyUnited.Tests.RepositoryTests
{
    public class PersonRepositoryTest
    {
        [Fact]
        public void GetPersonById_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));

            // Act
            var person = personRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(person);
        }

        [Fact]
        public void FindAll_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(a => a.FindAll())
                .Returns(new List<PersonEntity> {PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1())});

            // Act
            var persons = personRepository.Object.FindAll();

            // Assert
            Assert.NotNull(persons);
        }

        [Fact]
        public void Create_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(a => a.Create(It.IsAny<PersonEntity>()));
            personRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));

            // Act
            personRepository.Object.Create(
                PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));
            var person = personRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(person);
        }

        [Fact]
        public void Update_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(a => a.Update(It.IsAny<PersonEntity>()));
            personRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));

            // Act
            personRepository.Object.Create(
                PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));
            var person = personRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(person);
        }

        [Fact]
        public void Delete_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var personRepository = new Mock<IPersonRepository>();
            personRepository.Setup(a => a.Delete(It.IsAny<PersonEntity>()));
            personRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));

            // Act
            personRepository.Object.Create(
                PersonMapper.ToEntity(SampleData.SamplePersonData.ValidSamplePerson1()));
            var person = personRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(person);
        }
    }
}