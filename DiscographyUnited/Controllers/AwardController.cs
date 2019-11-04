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
    public class AwardController : ControllerBase
    {
        private readonly ILogger<AwardController> _logger;
        private readonly IAwardService _awardService;

        public AwardController(ILogger<AwardController> logger, IAwardService awardService)
        {
            _awardService = awardService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            _logger.LogInformation($"{nameof(AwardController)} : {nameof(Get)} was called.");
            try
            {
                var awards = _awardService.FindAll();
                return Ok(awards);
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
        public IActionResult GetAward(long id)
        {
            _logger.LogInformation($"{nameof(AwardController)} : {nameof(GetAward)} was called.");
            try
            {
                var award = _awardService.FindById(id);
                if (award == null) return NotFound("Award was not found");
                return Ok(award);
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

        [HttpPost(Name = "Award")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult PostAward([FromBody] AwardModel awardModel)
        {
            _logger.LogInformation($"{nameof(AwardController)} : {nameof(PostAward)} was called.");
            try
            {
                if (awardModel == null) return BadRequest("Award is required");

                if (_awardService.FindById(awardModel.Id) != null) return Conflict("Award already exists");

                _awardService.Create(awardModel);
                _awardService.Save();
                return Ok(awardModel);
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

        [HttpPut(Name = "Award")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateAward([FromBody] AwardModel awardModel)
        {
            _logger.LogInformation($"{nameof(AwardController)} : {nameof(UpdateAward)} was called.");
            try
            {
                if (awardModel == null) return BadRequest("Award is required");
                _awardService.Update(awardModel);
                _awardService.Save();
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

        [HttpDelete(Name = "Award/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(410)]
        [ProducesResponseType(500)]
        public IActionResult DeleteAward(long id)
        {
            _logger.LogInformation($"{nameof(AwardController)} : {nameof(DeleteAward)} was called.");
            try
            {
                var award = _awardService.FindById(id);
                if (award == null) return StatusCode((int) HttpStatusCode.Gone);
                _awardService.Delete(award);
                _awardService.Save();
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