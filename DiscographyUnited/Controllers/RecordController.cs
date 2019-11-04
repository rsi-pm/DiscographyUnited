using System;
using System.Data.Common;
using System.Net;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscographyUnited.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly ILogger<RecordController> _logger;
        private readonly IRecordService _recordService;

        public RecordController(ILogger<RecordController> logger, IRecordService recordService)
        {
            _recordService = recordService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            _logger.LogInformation($"{nameof(RecordController)} : {nameof(Get)} was called.");
            try
            {
                var record = _recordService.FindAll();
                if (record == null) return NotFound("Record was not found");
                return Ok(record);
            }
            catch (DbException exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetRecord(long id)
        {
            _logger.LogInformation($"{nameof(RecordController)} : {nameof(GetRecord)} was called.");
            try
            {
                var records = _recordService.FindById(id);
                return Ok(records);
            }
            catch (DbException exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpPost(Name = "Record")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult PostRecord([FromBody] RecordModel recordModel)
        {
            _logger.LogInformation($"{nameof(RecordController)} : {nameof(PostRecord)} was called.");
            try
            {
                if (recordModel == null)
                {
                    return BadRequest("Record is required");
                }

                if (_recordService.FindById(recordModel.Id) != null)
                {
                    return Conflict("Record already exists");
                }

                _recordService.Create(recordModel);
                _recordService.Save();
                return Ok("Record Created");
            }
            catch (DbException exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpPut(Name = "Record")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateRecord([FromBody] RecordModel recordModel)
        {
            _logger.LogInformation($"{nameof(RecordController)} : {nameof(UpdateRecord)} was called.");
            try
            {
                if (recordModel == null)
                {
                    return BadRequest("Record is required");
                }
                _recordService.Update(recordModel);
                _recordService.Save();
                return Ok();
            }
            catch (DbException exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpDelete(Name = "Record/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(410)]
        [ProducesResponseType(500)]
        public IActionResult DeleteRecord(long id)
        {
            _logger.LogInformation($"{nameof(RecordController)} : {nameof(DeleteRecord)} was called.");
            try
            {
                var record = _recordService.FindById(id);
                if (record == null)
                {
                    return StatusCode((int)HttpStatusCode.Gone);
                }
                _recordService.Delete(record);
                _recordService.Save();
                return Ok();
            }
            catch (DbException exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }
    }
}
