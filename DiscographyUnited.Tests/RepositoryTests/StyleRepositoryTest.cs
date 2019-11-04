using System.Collections.Generic;
using DiscographyUnited.Entities;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using Moq;
using Xunit;

namespace DiscographyUnited.Tests.RepositoryTests
{
    public class StyleRepositoryTest
    {
        [Fact]
        public void GetStyleById_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var styleRepository = new Mock<IStyleRepository>();
            styleRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));

            // Act
            var style = styleRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(style);
        }

        [Fact]
        public void FindAll_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var styleRepository = new Mock<IStyleRepository>();
            styleRepository.Setup(a => a.FindAll())
                .Returns(new List<StyleEntity> {StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1())});

            // Act
            var styles = styleRepository.Object.FindAll();

            // Assert
            Assert.NotNull(styles);
        }

        [Fact]
        public void Create_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var styleRepository = new Mock<IStyleRepository>();
            styleRepository.Setup(a => a.Create(It.IsAny<StyleEntity>()));
            styleRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));

            // Act
            styleRepository.Object.Create(
                StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));
            var style = styleRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(style);
        }

        [Fact]
        public void Update_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var styleRepository = new Mock<IStyleRepository>();
            styleRepository.Setup(a => a.Update(It.IsAny<StyleEntity>()));
            styleRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));

            // Act
            styleRepository.Object.Create(
                StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));
            var style = styleRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(style);
        }

        [Fact]
        public void Delete_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var styleRepository = new Mock<IStyleRepository>();
            styleRepository.Setup(a => a.Delete(It.IsAny<StyleEntity>()));
            styleRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));

            // Act
            styleRepository.Object.Create(
                StyleMapper.ToEntity(SampleData.SampleStyleData.ValidSampleStyle1()));
            var style = styleRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(style);
        }
    }
}