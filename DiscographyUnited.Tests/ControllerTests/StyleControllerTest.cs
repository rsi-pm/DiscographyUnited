using DiscographyUnited.Controllers;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DiscographyUnited.Tests.ControllerTests
{
    public class StyleControllerTest
    {
        private readonly StyleController _controller;

        public StyleControllerTest()
        {
            IStyleService service = new StyleServiceFake();
            ILogger<StyleController> logger = new Logger<StyleController>(new LoggerFactory());
            _controller = new StyleController(logger, service); 
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
        public void GetStyleById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetStyle(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostStyle_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var style = new StyleModel();

            // Act
            var result = _controller.PostStyle(style);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateStyle_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var style = new StyleModel();

            // Act
            var result = _controller.UpdateStyle(style);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteStyle_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.DeleteStyle(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetStyleById_WhenCalledIncorrectly_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetStyle(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostStyle_WhenCalledIncorrectly_ReturnsConflictResult()
        {
            // Arrange
            var style = new StyleModel{Id = 1};

            // Act
            var result = _controller.PostStyle(style);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public void UpdateStyle_WhenCalledIncorrectly_ReturnsBadResult()
        {
            // Arrange
            var style = new StyleModel{Id = -1};

            // Act
            var result = _controller.UpdateStyle(style);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteStyle_WhenCalledIncorrectly_ReturnsGoneResult()
        {
            // Act
            var result = _controller.DeleteStyle(-1);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
        }
    }
}
