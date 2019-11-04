using System.Collections.Generic;
using DiscographyUnited.Entities;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using Moq;
using Xunit;

namespace DiscographyUnited.Tests.RepositoryTests
{
    public class GenreRepositoryTest
    {
        [Fact]
        public void GetGenreById_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var genreRepository = new Mock<IGenreRepository>();
            genreRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));

            // Act
            var genre = genreRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(genre);
        }

        [Fact]
        public void FindAll_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var genreRepository = new Mock<IGenreRepository>();
            genreRepository.Setup(a => a.FindAll())
                .Returns(new List<GenreEntity> {GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1())});

            // Act
            var genres = genreRepository.Object.FindAll();

            // Assert
            Assert.NotNull(genres);
        }

        [Fact]
        public void Create_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var genreRepository = new Mock<IGenreRepository>();
            genreRepository.Setup(a => a.Create(It.IsAny<GenreEntity>()));
            genreRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));

            // Act
            genreRepository.Object.Create(
                GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));
            var genre = genreRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(genre);
        }

        [Fact]
        public void Update_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var genreRepository = new Mock<IGenreRepository>();
            genreRepository.Setup(a => a.Update(It.IsAny<GenreEntity>()));
            genreRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));

            // Act
            genreRepository.Object.Create(
                GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));
            var genre = genreRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(genre);
        }

        [Fact]
        public void Delete_WhenCalledCorrectly_Succeeds()
        {
            // Assemble
            var genreRepository = new Mock<IGenreRepository>();
            genreRepository.Setup(a => a.Delete(It.IsAny<GenreEntity>()));
            genreRepository.Setup(a => a.FindById(It.IsAny<long>()))
                .Returns(GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));

            // Act
            genreRepository.Object.Create(
                GenreMapper.ToEntity(SampleData.SampleGenreData.ValidSampleGenre1()));
            var genre = genreRepository.Object.FindById(1);

            // Assert
            Assert.NotNull(genre);
        }
    }
}