using Compugraf.Application.Service;
using Compugraf.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compugraf.Api.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonVm>))]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAllPerson();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonVm))]
        public async Task<IActionResult> GetPersonById(long id)
        {
            var result = await _personService.GetPersonById(id);

            if (result == null)
                return NotFound("Pessoa não encontrada");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonVm))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> Post(CreatePersonVm personVm)
        {

            try
            {
                var response = await _personService.AddPerson(personVm);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> Put(CreatePersonVm personVm, long id)
        {
            try
            {
                var response = await _personService.UpdatePerson(personVm, id);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _personService.DeletePerson(id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
