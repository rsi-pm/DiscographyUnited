using DiscographyUnited.Controllers;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DiscographyUnited.Tests.ControllerTests
{
    public class GenreControllerTest
    {
        private readonly GenreController _controller;

        public GenreControllerTest()
        {
            IGenreService service = new GenreServiceFake();
            ILogger<GenreController> logger = new Logger<GenreController>(new LoggerFactory());
            _controller = new GenreController(logger, service); 
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetGenreById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetGenre(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostGenre_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var genre = new GenreModel();

            // Act
            var result = _controller.PostGenre(genre);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateGenre_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var genre = new GenreModel();

            // Act
            var result = _controller.UpdateGenre(genre);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteGenre_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.DeleteGenre(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetGenreById_WhenCalledIncorrectly_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetGenre(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostGenre_WhenCalledIncorrectly_ReturnsConflictResult()
        {
            // Arrange
            var genre = new GenreModel{Id = 1};

            // Act
            var result = _controller.PostGenre(genre);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public void UpdateGenre_WhenCalledIncorrectly_ReturnsBadResult()
        {
            // Arrange
            var genre = new GenreModel{Id = -1};

            // Act
            var result = _controller.UpdateGenre(genre);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteGenre_WhenCalledIncorrectly_ReturnsGoneResult()
        {
            // Act
            var result = _controller.DeleteGenre(-1);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
        }
    }
}
