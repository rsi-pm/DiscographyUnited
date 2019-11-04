using DiscographyUnited.Controllers;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DiscographyUnited.Tests.ControllerTests
{
    public class RecordControllerTest
    {
        private readonly RecordController _controller;

        public RecordControllerTest()
        {
            IRecordService service = new RecordServiceFake();
            ILogger<RecordController> logger = new Logger<RecordController>(new LoggerFactory());
            _controller = new RecordController(logger, service); 
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
        public void GetRecordById_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetRecord(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostRecord_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var record = new RecordModel {Id = 4};

            // Act
            var result = _controller.PostRecord(record);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateRecord_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var record = SampleData.SampleRecordData.ValidSampleRecord1();

            // Act
            var result = _controller.UpdateRecord(record);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteRecord_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.DeleteRecord(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetRecordById_WhenCalledIncorrectly_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetRecord(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostRecord_WhenCalledIncorrectly_ReturnsConflictResult()
        {
            // Arrange
            var record = SampleData.SampleRecordData.ValidSampleRecord1();

            // Act
            var result = _controller.PostRecord(record);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public void UpdateRecord_WhenCalledIncorrectly_ReturnsNotFoundResult()
        {
            // Arrange
            var record = new RecordModel{Id = -1};

            // Act
            var result = _controller.UpdateRecord(record);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteRecord_WhenCalledIncorrectly_ReturnsGoneResult()
        {
            // Act
            var result = _controller.DeleteRecord(-1);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
        }
    }
}
