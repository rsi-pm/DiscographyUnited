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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            _logger.LogInformation($"{nameof(PersonController)} : {nameof(Get)} was called.");
            try
            {
                var persons = _personService.FindAll();
                return Ok(persons);
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
        public IActionResult GetPerson(long id)
        {
            _logger.LogInformation($"{nameof(PersonController)} : {nameof(GetPerson)} was called.");
            try
            {
                var persons = _personService.FindById(id);
                return Ok(persons);
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

        [HttpPost(Name = "Person")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult PostPerson([FromBody] PersonModel personModel)
        {
            _logger.LogInformation($"{nameof(PersonController)} : {nameof(PostPerson)} was called.");
            try
            {
                if (personModel == null)
                {
                    return BadRequest("Person is required");
                }

                if (_personService.FindById(personModel.Id) != null)
                {
                    return Conflict("Person already exists");
                }

                _personService.Create(personModel);
                _personService.Save();
                return Ok("Person Created");
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

        [HttpPut(Name = "Person")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdatePerson([FromBody] PersonModel personModel)
        {
            _logger.LogInformation($"{nameof(PersonController)} : {nameof(UpdatePerson)} was called.");
            try
            {
                if (personModel == null)
                {
                    return BadRequest("Person is required");
                }
                _personService.Update(personModel);
                _personService.Save();
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

        [HttpDelete(Name = "Person/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(410)]
        [ProducesResponseType(500)]
        public IActionResult DeletePerson(long id)
        {
            _logger.LogInformation($"{nameof(PersonController)} : {nameof(DeletePerson)} was called.");
            try
            {
                var person = _personService.FindById(id);
                if (person == null)
                {
                    return StatusCode((int)HttpStatusCode.Gone);
                }
                _personService.Delete(person);
                _personService.Save();
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
