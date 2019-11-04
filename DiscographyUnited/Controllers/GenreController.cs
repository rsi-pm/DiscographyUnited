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
    public class GenreController : ControllerBase
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IGenreService _genreService;

        public GenreController(ILogger<GenreController> logger, IGenreService genreService)
        {
            _genreService = genreService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            _logger.LogInformation($"{nameof(GenreController)} : {nameof(Get)} was called.");
            try
            {
                var genres = _genreService.FindAll();
                return Ok(genres);
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
        public IActionResult GetGenre(long id)
        {
            _logger.LogInformation($"{nameof(GenreController)} : {nameof(GetGenre)} was called.");
            try
            {
                var genre = _genreService.FindById(id);
                if (genre == null) return NotFound("Genre was not found");
                return Ok(genre);
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

        [HttpPost(Name = "Genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult PostGenre([FromBody] GenreModel genreModel)
        {
            _logger.LogInformation($"{nameof(GenreController)} : {nameof(PostGenre)} was called.");
            try
            {
                if (genreModel == null) return BadRequest("Genre is required");

                if (_genreService.FindById(genreModel.Id) != null) return Conflict("Genre already exists");

                _genreService.Create(genreModel);
                _genreService.Save();
                return Ok("Genre Created");
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

        [HttpPut(Name = "Genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateGenre([FromBody] GenreModel genreModel)
        {
            _logger.LogInformation($"{nameof(GenreController)} : {nameof(UpdateGenre)} was called.");
            try
            {
                if (genreModel == null) return BadRequest("Genre is required");
                if (_genreService.FindById(genreModel.Id) == null) return NotFound("Genre not found");
                _genreService.Update(genreModel);
                _genreService.Save();
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

        [HttpDelete(Name = "Genre/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(410)]
        [ProducesResponseType(500)]
        public IActionResult DeleteGenre(long id)
        {
            _logger.LogInformation($"{nameof(GenreController)} : {nameof(DeleteGenre)} was called.");
            try
            {
                var genre = _genreService.FindById(id);
                if (genre == null) return StatusCode((int) HttpStatusCode.Gone);
                _genreService.Delete(genre);
                _genreService.Save();
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