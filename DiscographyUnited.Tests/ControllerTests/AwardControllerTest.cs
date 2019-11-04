using System.Threading.Tasks;
using DiscographyUnited.Controllers;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DiscographyUnited.Tests.ControllerTests
{
    public class AwardControllerTest
    {
        private readonly IAwardService _service;
        private readonly ILogger<AwardController> _logger;
        private readonly AwardController _controller;

        public AwardControllerTest()
        {
            _service = new AwardServiceFake();
            _logger = new Logger<AwardController>(new LoggerFactory());
            _controller = new AwardController(_logger, _service); 
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
        public void GetAwardById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAward(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostAward_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var award = new AwardModel();

            // Act
            var result = _controller.PostAward(award);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateAward_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var award = new AwardModel();

            // Act
            var result = _controller.UpdateAward(award);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteAward_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.DeleteAward(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetAwardById_WhenCalledIncorrectly_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetAward(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostAward_WhenCalledIncorrectly_ReturnsConflictResult()
        {
            // Arrange
            var award = new AwardModel{Id = 1};

            // Act
            var result = _controller.PostAward(award);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public void UpdateAward_WhenCalledIncorrectly_ReturnsBadResult()
        {
            // Arrange
            var award = new AwardModel{Id = 1};

            // Act
            var result = _controller.UpdateAward(award);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteAward_WhenCalledIncorrectly_ReturnsGoneResult()
        {
            // Act
            var result = _controller.DeleteAward(-1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
