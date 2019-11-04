using DiscographyUnited.Controllers;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DiscographyUnited.Tests.ControllerTests
{
    public class PersonControllerTest
    {
        private readonly PersonController _controller;

        public PersonControllerTest()
        {
            IPersonService service = new PersonServiceFake();
            ILogger<PersonController> logger = new Logger<PersonController>(new LoggerFactory());
            _controller = new PersonController(logger, service); 
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
        public void GetPersonById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetPerson(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostPerson_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var person = new PersonModel();

            // Act
            var result = _controller.PostPerson(person);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdatePerson_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var person = new PersonModel();

            // Act
            var result = _controller.UpdatePerson(person);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeletePerson_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.DeletePerson(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetPersonById_WhenCalledIncorrectly_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetPerson(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostPerson_WhenCalledIncorrectly_ReturnsConflictResult()
        {
            // Arrange
            var person = new PersonModel{Id = 1};

            // Act
            var result = _controller.PostPerson(person);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public void UpdatePerson_WhenCalledIncorrectly_ReturnsBadResult()
        {
            // Arrange
            var person = new PersonModel{Id = -1};

            // Act
            var result = _controller.UpdatePerson(person);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeletePerson_WhenCalledIncorrectly_ReturnsGoneResult()
        {
            // Act
            var result = _controller.DeletePerson(-1);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
        }
    }
}
