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
    public class StyleController : ControllerBase
    {
        private readonly ILogger<StyleController> _logger;
        private readonly IStyleService _styleService;

        public StyleController(ILogger<StyleController> logger, IStyleService styleService)
        {
            _styleService = styleService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            _logger.LogInformation($"{nameof(StyleController)} : {nameof(Get)} was called.");
            try
            {
                var style = _styleService.FindAll();
                if (style == null) return NotFound("Style was not found");
                return Ok(style);
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
        public IActionResult GetStyle(long id)
        {
            _logger.LogInformation($"{nameof(StyleController)} : {nameof(GetStyle)} was called.");
            try
            {
                var styles = _styleService.FindById(id);
                if (styles == null) return NotFound("Style Not Found");
                return Ok(styles);
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

        [HttpPost(Name = "Style")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult PostStyle([FromBody] StyleModel styleModel)
        {
            _logger.LogInformation($"{nameof(StyleController)} : {nameof(PostStyle)} was called.");
            try
            {
                if (styleModel == null) return BadRequest("Style is required");

                if (_styleService.FindById(styleModel.Id) != null) return Conflict("Style already exists");

                _styleService.Create(styleModel);
                _styleService.Save();
                return Ok("Style Created");
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

        [HttpPut(Name = "Style")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateStyle([FromBody] StyleModel styleModel)
        {
            _logger.LogInformation($"{nameof(StyleController)} : {nameof(UpdateStyle)} was called.");
            try
            {
                if (styleModel == null) return BadRequest("Style is required");
                if (_styleService.FindById(styleModel.Id) == null) return NotFound("Style not found");
                _styleService.Update(styleModel);
                _styleService.Save();
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

        [HttpDelete(Name = "Style/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(410)]
        [ProducesResponseType(500)]
        public IActionResult DeleteStyle(long id)
        {
            _logger.LogInformation($"{nameof(StyleController)} : {nameof(DeleteStyle)} was called.");
            try
            {
                var style = _styleService.FindById(id);
                if (style == null) return StatusCode((int) HttpStatusCode.Gone);
                _styleService.Delete(style);
                _styleService.Save();
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