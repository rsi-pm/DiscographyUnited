using System.Collections.Generic;
using DiscographyUnited.Entities;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using Moq;
using Xunit;

namespace DiscographyUnited.Tests.RepositoryTests
{
    public class AwardRepositoryTest
    {
        [Fact]
        public void GetAwardById_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var awardRepository = new Mock<IAwardRepository>();
            awardRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));

            // Act
            var award = awardRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(award);
        }

        [Fact]
        public void FindAll_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var awardRepository = new Mock<IAwardRepository>();
            awardRepository.Setup(a => a.FindAll())
                .Returns(new List<AwardEntity> {AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1())});

            // Act
            var awards = awardRepository.Object.FindAll();

            // Assert
            Assert.NotNull(awards);
        }

        [Fact]
        public void Create_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var awardRepository = new Mock<IAwardRepository>();
            awardRepository.Setup(a => a.Create(It.IsAny<AwardEntity>()));
            awardRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));

            // Act
            awardRepository.Object.Create(
                AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));
            var award = awardRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(award);
        }

        [Fact]
        public void Update_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var awardRepository = new Mock<IAwardRepository>();
            awardRepository.Setup(a => a.Update(It.IsAny<AwardEntity>()));
            awardRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));

            // Act
            awardRepository.Object.Create(
                AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));
            var award = awardRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(award);
        }

        [Fact]
        public void Delete_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var awardRepository = new Mock<IAwardRepository>();
            awardRepository.Setup(a => a.Delete(It.IsAny<AwardEntity>()));
            awardRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));

            // Act
            awardRepository.Object.Create(
                AwardMapper.ToEntity(SampleData.SampleAwardData.ValidSampleAward1()));
            var award = awardRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(award);
        }
    }
}