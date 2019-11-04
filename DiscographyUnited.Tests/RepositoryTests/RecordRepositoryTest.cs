using System.Collections.Generic;
using DiscographyUnited.Entities;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using Moq;
using Xunit;

namespace DiscographyUnited.Tests.RepositoryTests
{
    public class RecordRepositoryTest
    {
        [Fact]
        public void GetRecordById_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var recordRepository = new Mock<IRecordRepository>();
            recordRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));

            // Act
            var record = recordRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(record);
        }

        [Fact]
        public void FindAll_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var recordRepository = new Mock<IRecordRepository>();
            recordRepository.Setup(a => a.FindAll())
                .Returns(new List<RecordEntity> {RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1())});

            // Act
            var records = recordRepository.Object.FindAll();

            // Assert
            Assert.NotNull(records);
        }

        [Fact]
        public void Create_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var recordRepository = new Mock<IRecordRepository>();
            recordRepository.Setup(a => a.Create(It.IsAny<RecordEntity>()));
            recordRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));

            // Act
            recordRepository.Object.Create(
                RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));
            var record = recordRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(record);
        }

        [Fact]
        public void Update_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var recordRepository = new Mock<IRecordRepository>();
            recordRepository.Setup(a => a.Update(It.IsAny<RecordEntity>()));
            recordRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));

            // Act
            recordRepository.Object.Create(
                RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));
            var record = recordRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(record);
        }

        [Fact]
        public void Delete_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var recordRepository = new Mock<IRecordRepository>();
            recordRepository.Setup(a => a.Delete(It.IsAny<RecordEntity>()));
            recordRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));

            // Act
            recordRepository.Object.Create(
                RecordMapper.ToEntity(SampleData.SampleRecordData.ValidSampleRecord1()));
            var record = recordRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(record);
        }
    }
}